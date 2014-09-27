using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Todos
{
    public interface IEntity<K>
    {
        K Id { get; set; }
        DateTime Created { get; set; }
        DateTime Updated { get; set; }
    }
}
