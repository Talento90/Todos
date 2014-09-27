using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Repository.SqlServer
{
    public class SqlServerRepository<K, T> : IRepository<K, T> where T : class, IEntity<K>
    {
        /// <summary>
        /// The context
        /// </summary>
        private DbContext context;
        /// <summary>
        /// The database set
        /// </summary>
        protected DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerRepository{K, T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public SqlServerRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<T> GetById(K id)
        {
            return this.dbSet.FindAsync(id);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<T> Insert(T entity)
        {
            T model = this.dbSet.Add(entity);
            await this.context.SaveChangesAsync();
            return model;
        }

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public async Task<T> Delete(K key)
        {
            T entity = await this.GetById(key);

            if (entity == null)
                return default(T);

            this.dbSet.Remove(entity);

            await this.context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<T> Update(T entity)
        {
            entity.Updated = DateTime.UtcNow;
            this.dbSet.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Task<IQueryable<T>> GetAll()
        {
            return Task.FromResult(this.dbSet.AsQueryable());
        }

    }
}
