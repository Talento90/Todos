using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Todos.Managers;
using Todos.Models;

namespace Todos.WebApi.Controllers
{
    /// <summary>
    /// Task api controller
    /// </summary>
    [RoutePrefix("api/Task")]
    public class TaskController : ApiController
    {
        private ITaskManager taskManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="taskManager">The task manager.</param>
        public TaskController(ITaskManager taskManager)
        {
            this.taskManager = taskManager;
        }


        /// <summary>
        /// Gets all taks. Support Odata querys.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IQueryable<Todos.Models.Task>> GetAll()
        {
            return this.taskManager.GetAll();
        }

        /// <summary>
        /// Gets a task by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<Todos.Models.Task> Get(string id)
        {
            Models.Task task = await this.taskManager.GetById(id);

            if (task == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return task;
        }

        /// <summary>
        /// Create a new task.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPost]
        public Task<Todos.Models.Task> Post(Todos.Models.Task value)
        {
            return this.taskManager.Create(value);
        }

        /// <summary>
        /// Update a new task.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Todos.Models.Task> Put(string id, Todos.Models.Task value)
        {
            Models.Task updatedTask = await this.taskManager.Update(id,value);

            if(updatedTask == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return updatedTask;
        }

        /// <summary>
        /// Deletes a task by Id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Todos.Models.Task> Delete(string id)
        {
            Models.Task deletedTask = await this.taskManager.Delete(id);

            if (deletedTask == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return deletedTask;
        }
    }
}
