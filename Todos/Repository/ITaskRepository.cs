using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Models;


namespace Todos.Repository
{
    public interface ITaskRepository : IRepository<string, Todos.Models.Task>
    {
        Task<IEnumerable<Todos.Models.Task>> GetAllCompletedTasks();
    }
}
