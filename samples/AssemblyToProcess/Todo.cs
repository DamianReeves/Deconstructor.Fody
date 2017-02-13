using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyToProcess
{
    public class Todo
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? DueDate { get; set; }
    }

    public class TodoWithDeconstructor : Todo
    {
        public void Deconstructor(out string subject, out string description, out DateTimeOffset? dueDate)
        {
            subject = Subject;
            description = Description;
            dueDate = DueDate;
        }
    }
}
