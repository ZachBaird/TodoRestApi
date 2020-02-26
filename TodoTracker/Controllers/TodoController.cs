using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTracker.Models;

namespace TodoTracker.Controllers
{
    [ApiController]
    [Route("[controller]", Name = "todo")]
    public class TodoController : ControllerBase
    {
        List<Todo> _todos = new List<Todo>()
        {
            new Todo { Id = 1, Name = "Complete Todo app", Status = Status.Dev, DateCreated = DateTime.Now, DateFinished = null },
            new Todo { Id = 2, Name = "Complete Pet Profile app", Status = Status.Backlog, DateCreated = DateTime.Now, DateFinished = null }
        };

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todos.ToArray(); 
        }

        [HttpPost]
        public IEnumerable<Todo> Post(Todo newTodo)
        {
            _todos.Add(newTodo);

            return _todos.ToArray();
        }           
    }
}
