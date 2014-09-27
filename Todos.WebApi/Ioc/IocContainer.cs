using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Todos.WebApi
{
    /// <summary>
    /// IOC container.
    /// </summary>
    /// <seealso cref="T:System.Web.Http.Dependencies.IDependencyResolver"/>
    public class IocContainer : ScopeContainer, System.Web.Http.Dependencies.IDependencyResolver
    {
        /// <summary>
        /// Initializes a new instance of the IocContainer class.
        /// </summary>
        /// <param name="container">The container.</param>
        public IocContainer(IUnityContainer container) : base(container)
        {

        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        /// <seealso cref="M:System.Web.Http.Dependencies.IDependencyResolver.BeginScope()"/>
        public IDependencyScope BeginScope()
        {
            var child = this.Container.CreateChildContainer();
            return new ScopeContainer(child);
        }

        #region Required for MVC4 Dependency Resolver

        /// <summary>
        /// Enumerates get all instances in this collection.
        /// </summary>
        /// <typeparam name="TService">Type of the service.</typeparam>
        /// <returns>
        /// An enumerator that allows foreach to be used to process get all instances&lt; t service&gt; in this collection.
        /// </returns>
        public IEnumerable<TService> GetAllInstances<TService>()
        {
            try
            {
                return this.Container.ResolveAll<TService>();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Enumerates get all instances in this collection.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process get all instances in this collection.
        /// </returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            try
            {
                return this.Container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        /// <typeparam name="TService">Type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The instance&lt; t service&gt;
        /// </returns>
        public TService GetInstance<TService>(string key)
        {
            try
            {
                return this.Container.IsRegistered<TService>() ? this.Container.Resolve<TService>() : default(TService);
            }
            catch
            {
                return default(TService);
            }
        }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        /// <typeparam name="TService">Type of the service.</typeparam>
        /// <returns>
        /// The instance&lt; t service&gt;
        /// </returns>
        public TService GetInstance<TService>()
        {
            try
            {
                return this.Container.IsRegistered<TService>() ? this.Container.Resolve<TService>() : default(TService);
            }
            catch
            {
                return default(TService);
            }
        }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The instance.
        /// </returns>
        public object GetInstance(Type serviceType, string key)
        {
            try
            {
                return this.Container.IsRegistered(serviceType, key) ? this.Container.Resolve(serviceType, key) : null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets an instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// The instance.
        /// </returns>
        public object GetInstance(Type serviceType)
        {
            try
            {

                return this.Container.IsRegistered(serviceType) ? this.Container.Resolve(serviceType) : null;
            }
            catch
            {
                return null;
            }
        }

        #endregion


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

}