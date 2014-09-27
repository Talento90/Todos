using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Todos.WebApi
{

    public class WebApiApplication : System.Web.HttpApplication
    {

        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(
         () =>
         {
             IUnityContainer currentContainer = new UnityContainer().LoadConfiguration();
             return currentContainer;
         },
         System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);


        /// <summary>
        /// Gets the unity container.
        /// </summary>
        /// <value>
        /// The unity container.
        /// </value>
        public static IUnityContainer UnityContainer
        {
            get
            {
                return _container.Value;
            }
        }

        protected void Application_Start()
        {

            // Setup IoC
            var abstractedContainer = new IocContainer(UnityContainer);


            GlobalConfiguration.Configure((config) =>
                    {
                        Startup.ConfigureWebApi(config, UnityContainer);
                    });
          

            // Startup MVC (It must be started after webapi because routes conflict)
            System.Web.Mvc.DependencyResolver.SetResolver(abstractedContainer);


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        /// <summary>
        /// Executes when the application ends.
        /// </summary>
        protected void Application_End()
        {
            if (_container.IsValueCreated)
                _container.Value.Dispose();
        }
    }
}
