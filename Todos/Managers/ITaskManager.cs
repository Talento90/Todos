using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Managers
{
    public interface ITaskManager
    {
        Task<IQueryable<Models.Task>> GetAll();
        Task<Models.Task> GetById(string id);
        Task<Models.Task> Update(string id, Models.Task task);
        Task<Models.Task> Delete(string id);
        Task<Models.Task> Create(Models.Task task);
    }
}
