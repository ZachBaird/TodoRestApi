using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoTracker.Models;

namespace TodoTracker.Services
{
    // Todo Service with CRUD functionality.
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _todos;

        // The constructor initializes a client with the connection string from the ITodoDatabaseSettings
        //  interface and gets the database. The todos collection is then assigned with .GetCollection.
        public TodoService(ITodoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _todos = database.GetCollection<Todo>(settings.TodoCollectionName);
        }

        public List<Todo> Get() =>
            _todos.Find(todo => true).ToList();

        public Todo Get(string id) =>
            _todos.Find<Todo>(todo => todo.Id == id).FirstOrDefault();

        public Todo Create(Todo todo)
        {
            _todos.InsertOne(todo);
            return todo;
        }

        public void Update(string id, Todo todoIn) =>
            _todos.ReplaceOne(todo => todo.Id == id, todoIn);

        public void Remove(Todo todoIn) =>
            _todos.DeleteOne(todo => todo.Id == todoIn.Id);

        public void Remove(string id) =>
            _todos.DeleteOne(todo => todo.Id == id);
    }
}
