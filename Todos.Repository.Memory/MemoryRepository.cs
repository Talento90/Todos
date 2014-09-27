using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Repository.Memory
{
    public class MemoryRepository<K,T> : IRepository<K, T> where T : IEntity<K>
    {

        protected Dictionary<K, T> Repository;

        public MemoryRepository()
        {
            this.Repository = new Dictionary<K, T>();
        }

        public Task<T> GetById(K key)
        {
            T value = default(T);
            this.Repository.TryGetValue(key, out value);
            return Task.FromResult(value);
        }

        public async Task<T> Insert(T value)
        {

            T entity = await this.GetById(value.Id);

            if (entity != null)
            {
                throw new RepositoryException(string.Format("Already exist a value with the Id {0}", value.Id));
            }

            value.Created = DateTime.UtcNow;
            value.Updated = DateTime.UtcNow;
            this.Repository.Add(value.Id, value);

            return value;
        }

        public async Task<T> Delete(K key)
        {
            T entity = await this.GetById(key);
            this.Repository.Remove(key);
            return entity;
        }

        public async Task<T> Update(T value)
        {
            T entity = await this.GetById(value.Id);
            this.Repository.Remove(entity.Id);
            this.Repository.Add(value.Id, value);
            value.Updated = DateTime.UtcNow;
            return value;
        }

        public Task<IQueryable<T>> GetAll()
        {
            return Task.FromResult(this.Repository.Values.AsQueryable());
        }
    }
}
