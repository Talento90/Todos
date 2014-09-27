using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Managers
{
    public interface IManager<K,T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(K id);
        Task<T> Update(K id, T value);
        Task<T> Delete(K id);
        Task<T> Create(T value);
    }
}
