using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Todos.WebApi.ApiUtils
{
    interface IGenericApiController<K,T>
    {
        [HttpGet]
        Task<IQueryable<T>> GetAll();

        [HttpGet]
        Task<T> GetById(K id);

        [HttpPut]
        Task<T> Update(K id, T value);
        
        [HttpDelete]
        Task<T> Delete(K id);

        [HttpPost]
        Task<T> Create(T value);
    }
}
