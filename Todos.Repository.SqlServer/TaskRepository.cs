using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Todos.Repository.SqlServer
{
    /// <summary>
    /// Task Repository in SqlServer
    /// </summary>
    public class TaskRepository : SqlServerRepository<string, Models.Task>, ITaskRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TaskRepository(DbContext context): base(context)
        {

        }

        /// <summary>
        /// Gets all completed tasks.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetAllCompletedTasks()
        {
            return await (from t in this.dbSet
                          where t.Completed
                          select t).ToListAsync();
        }
    }
}
