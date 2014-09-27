using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Repository.Memory
{
    public class TaskRepository : MemoryRepository<string, Models.Task>, ITaskRepository
    {
        public Task<IEnumerable<Models.Task>> GetAllCompletedTasks()
        {
            return Task.FromResult(this.Repository.Values.Where(t => t.Completed));
        }
    }
}
