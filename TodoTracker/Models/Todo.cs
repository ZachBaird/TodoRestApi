using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoTracker.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateFinished { get; set; }

    }

    public enum Status
    {
        Backlog,
        Committed,
        Dev,
        Deploy,
        Finished
    }
}
