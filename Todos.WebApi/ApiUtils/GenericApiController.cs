using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Todos.Managers;

namespace Todos.WebApi.ApiUtils
{

    public class GenericApiController<K,T> : ApiController, IGenericApiController<K,T> where T : IEntity<K>
    {
        private IManager<K,T> manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericApiController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>
        public GenericApiController(IManager<K,T> manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// Gets all values. Support Odata querys.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IQueryable<T>> GetAll()
        {
            return this.manager.GetAll();
        }

        /// <summary>
        /// Gets a value by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<T> GetById(K id)
        {
            T value = await this.manager.GetById(id);

            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return value;
        }

        /// <summary>
        /// Create a new value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<T> Create(T value)
        {
            return this.manager.Create(value);
        }

        /// <summary>
        /// Update a value.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<T> Update(K id, T value)
        {
           
            T updatedValue = await this.manager.Update(id,value);

            if(updatedValue == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return updatedValue;
        }

        /// <summary>
        /// Deletes value by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<T> Delete(K id)
        {
            
            T deletedTask = await this.manager.Delete(id);

            if (deletedTask == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return deletedTask;
        }
    }
}