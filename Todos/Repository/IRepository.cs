using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Repository
{
    public interface IRepository<K,T> where T : IEntity<K>
    {
        Task<T> GetById(K key);
        Task<T> Insert(T value);
        Task<T> Delete(K key);
        Task<T> Update(T value);
        Task<IQueryable<T>> GetAll();
    }
}
