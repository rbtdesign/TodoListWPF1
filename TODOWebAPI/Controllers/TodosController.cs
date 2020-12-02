using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODODesktopUI.Library;

namespace TODOWebAPI.Controllers
{
    public class TodosController : ApiController
    {
        // Demo data Initialization
        private static List<Todo> Todos = new List<Todo>();
        private static int count = 4;

        static TodosController()
        {
            Todos.Add(new Todo() { Title = "Todo 1", Id = 1, IsCompleted = true });
            Todos.Add(new Todo() { Title = "Todo 2", Id = 2, IsCompleted = false });
            Todos.Add(new Todo() { Title = "Todo 3", Id = 3, IsCompleted = true });
            Todos.Add(new Todo() { Title = "Todo 4", Id = 4, IsCompleted = true });
        }

        // You can precise Route with 
        // [Route("api/Todos/GetXXX")] // Apply on the following command, names don't have to match
        // [HttpGet] // Precise the type of command it accept
        // [Route("api/Todos/GetXXX/{userId:int"/{age:int})] // Add parameter


        // GET: api/Todos
        public List<Todo> Get()
        {
            return Todos;
        }

        //GET: api/Todos/5
        public Todo Get(int id)
        {
            return Todos.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Todos
        public Todo Post([FromBody] string title)
        {
            // Logic to verify title

            // Logic to add new todo to fake db
            count++; // Increase counter for fake ID
            Todo todo = new Todo() { Title = title, Id = count };
            Todos.Add(todo); // Add to fake DB

            return todo;

        }

        // PUT: api/Todos/5
        public List<Todo> Put([FromBody] Todo todo)
        {
            var editedTodo = Todos.FirstOrDefault(t => t.Id == todo.Id);

            if (todo != null)
                editedTodo.Title = todo.Title;
            
            return Todos;
        }

        // DELETE: api/Todos/5
        public void Delete(int id)
        {
            Todos.Remove(Todos.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
