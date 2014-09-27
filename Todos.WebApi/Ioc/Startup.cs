using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.OData.Extensions;
using ZON.Http;
using ZON.Http.Logging;
using DIP.Convention;
using DIP.Services.WebApi.Handlers;
using DIP.Validation;
using DIP.WebApi.Handlers;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Owin;

namespace DIP.WebApi
{

    /// <summary>
    /// Startup.
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// Configure web API.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="container">The container.</param>
        public static void ConfigureWebApi(HttpConfiguration config, IUnityContainer container)
        {
            var abstractedContainer = new IocContainer(container);

            //container.RegisterInstance(config);

            config.DependencyResolver = abstractedContainer;
            config.Filters.Add(new ExceptionHandlingAttribute());
            config.Filters.Add(new ValidationActionAttribute());

            if ((ConfigurationManager.AppSettings["WebApi.EnablePrettyHandler"] ?? "true").Equals("true", StringComparison.InvariantCultureIgnoreCase))
                config.MessageHandlers.Add(new PrettyHandler());

            // Logging & Tracing
            var customErrorsConfig = ConfigurationManager.GetSection("system.web/customErrors") as CustomErrorsSection;
            if (customErrorsConfig != null)
            {
                switch (customErrorsConfig.Mode)
                {
                    case CustomErrorsMode.RemoteOnly:
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.LocalOnly;
                        break;
                    case CustomErrorsMode.On:
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Never;
                        break;
                    case CustomErrorsMode.Off:
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
                        break;
                    default:
                        config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Default;
                        break;
                }
            }

            if ((ConfigurationManager.AppSettings["WebApi.EnableSystemTracing"] ?? "false").Equals("true", StringComparison.InvariantCultureIgnoreCase))
                config.EnableSystemDiagnosticsTracing();

            if ((ConfigurationManager.AppSettings["WebApi.EnableApiLogger"] ?? ConfigurationManager.AppSettings["DIP.EnableApiLogger"] ?? "true").Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                if (container.IsRegistered<HttpLogger>())
                {
                    var httpLogger = container.Resolve<HttpLogger>();
                    httpLogger.EnableSystemDiagnosticsTracing();
                    config.MessageHandlers.Add(httpLogger);
                }
            }

            config.MapHttpAttributeRoutes();

            // Routes
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            // OData
            config.AddODataQueryFilter();

            // Formatters
            var jsonFormatter = config.Formatters.JsonFormatter;
            config.Formatters.Clear();
            config.Formatters.Add(jsonFormatter);
            config.Formatters.JsonFormatter.Indent = true;
        }

        /// <summary>
        /// Configurations the given application.
        /// </summary>
        /// <exception cref="Exception">Thrown when an exception error condition occurs.</exception>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            try
            {
                var owinVersion = Assembly.GetAssembly(typeof(Microsoft.Owin.Builder.AppBuilder)).GetName().Version;

                Trace.TraceInformation("OWIN starting (v{0})", owinVersion);

                // SignalR
                if ((ConfigurationManager.AppSettings["SignalR.Enabled"] ?? "true").Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    this.ConfigureSignalR(WebApiApplication.UnityContainer);
                    app.MapSignalR();
                }

                if ((ConfigurationManager.AppSettings["owin:useWebApi"] ?? "false").Equals("true", StringComparison.InvariantCultureIgnoreCase))
                {
                    HttpConfiguration config = new HttpConfiguration();
                    Startup.ConfigureWebApi(config, WebApiApplication.UnityContainer);
                    app.UseWebApi(config);

                }

                Trace.TraceInformation("OWIN started (v{0})", owinVersion);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error: {0}", ex);
                throw;
            }
        }

        private void ConfigureSignalR(IUnityContainer container)
        {
            bool autoRegisterHubs = true;

            if (autoRegisterHubs)
            {
                var hubTypes = (from hub in Assembly.GetExecutingAssembly().GetTypes()
                                where hub.Namespace == "DIP.WebApi.Hubs"
                                && hub.GetInterfaces().Contains(typeof(Microsoft.AspNet.SignalR.Hubs.IHub))
                                select hub).ToList();


                foreach (var hubType in hubTypes)
                    container.RegisterType(hubType, new ContainerControlledLifetimeManager());

            }

            GlobalHost.DependencyResolver = new SignalRUnityDependencyResolver(container);

            Trace.TraceInformation("SignalR started (v{0})", Assembly.GetAssembly(typeof(GlobalHost)).GetName().Version);
        }

    }
}