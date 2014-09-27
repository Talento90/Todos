using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos
{
    public class TodosException : Exception
    {

        public TodosException(string message)
            : base(message)
        {

        }
    }
}
