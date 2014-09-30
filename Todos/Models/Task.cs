using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Models
{
    public class Task : IEntity<string>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public Task()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
