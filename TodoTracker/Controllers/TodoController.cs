using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoTracker.Models;
using TodoTracker.Services;

namespace TodoTracker.Controllers
{
    [ApiController]
    [Route("[controller]", Name = "todo")]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService;

        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<List<Todo>> Get() =>
            _todoService.Get();

        [HttpGet("{id:length(24)}", Name = "GetTodo")]
        public ActionResult<Todo> Get(string id)
        {
            var todo = _todoService.Get(id);

            if (todo == null)
                return NotFound();

            return todo;
        }

        [HttpPost]
        public ActionResult<Todo> Create(Todo todo)
        {
            if (todo.DateCreated == null)
                todo.DateCreated = DateTime.Now;

            _todoService.Create(todo);            

            return CreatedAtRoute("GetTodo", new { id = todo.Id.ToString() }, todo);
        }
    }
}
