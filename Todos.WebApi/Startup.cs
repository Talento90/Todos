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
using Microsoft.Practices.Unity;
using Owin;
using Todos.WebApi;

namespace Todos.WebApi
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

            config.DependencyResolver = abstractedContainer;
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
            HttpConfiguration config = new HttpConfiguration();
            Startup.ConfigureWebApi(config, WebApiApplication.UnityContainer);
            app.UseWebApi(config);
        }
    }
}