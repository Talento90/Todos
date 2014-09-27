using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Managers;
using Todos.Repository;

namespace Todos.Manager.Task
{
    public class TaskManager : ITaskManager
    {
        private ITaskRepository taskRepository;

        public TaskManager(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        public Task<IQueryable<Models.Task>> GetAll()
        {
            return this.taskRepository.GetAll();
        }

        public Task<Models.Task> GetById(string id)
        {
            return this.taskRepository.GetById(id);
        }

        public async Task<Models.Task> Update(string id, Models.Task task)
        {
            Models.Task oldTask = await this.taskRepository.GetById(id);

            if (oldTask == null)
                return null;

            oldTask = await this.taskRepository.Update(task);

            return oldTask;
        }

        public Task<Models.Task> Delete(string id)
        {
            return this.taskRepository.Delete(id);
        }


        public Task<Models.Task> Create(Models.Task task)
        {
            return this.taskRepository.Insert(task);
        }
    }
}
