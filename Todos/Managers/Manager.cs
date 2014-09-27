using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Repository;

namespace Todos.Managers
{
    public class Manager<K,T> : IManager<K,T> where T : IEntity<K>
    {

        private IRepository<K,T> repository;

        public Manager(IRepository<K,T> repository)
        {
            this.repository = repository;
        }


        public Task<IQueryable<T>> GetAll()
        {
            return this.repository.GetAll();
        }

        public Task<T> GetById(K id)
        {
            return this.repository.GetById(id);
        }

        public async Task<T> Update(K id, T value)
        {
            T oldValue = await this.repository.Update(value);

            if (oldValue == null)
            {
                return default(T);
            }

            return await this.repository.Update(value);
        }

        public Task<T> Delete(K id)
        {
            return this.repository.Delete(id);
        }

        public  Task<T> Create(T value)
        {
            return this.repository.Insert(value);
        }
    }
}
