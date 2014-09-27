using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;

namespace Todos.WebApi
{
    /// <summary>
    /// Scope container.
    /// </summary>
    /// <seealso cref="T:System.Web.Http.Dependencies.IDependencyScope"/>
    public class ScopeContainer : IDependencyScope
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        protected IUnityContainer Container { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ScopeContainer class.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when one or more required arguments are null.</exception>
        /// <param name="container">The container.</param>
        public ScopeContainer(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.Container = container;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        /// <seealso cref="M:System.Web.Http.Dependencies.IDependencyScope.GetService(Type)"/>
        public object GetService(Type serviceType)
        {
            if (typeof(IHttpController).IsAssignableFrom(serviceType))
            {
                return this.Container.Resolve(serviceType);
            }

            try
            {
                return this.Container.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        /// <seealso cref="M:System.Web.Http.Dependencies.IDependencyScope.GetServices(Type)"/>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.ResolveAll(serviceType);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Container.Dispose();
            }
        }
    }
}