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
        List<Todo> Todos = new List<Todo>();

        public TodosController()
        {
            Todos.Add(new Todo() { Title = "Todo 1", IsCompleted = true });
            Todos.Add(new Todo() { Title = "Todo 2", IsCompleted = false });
            Todos.Add(new Todo() { Title = "Todo 3", IsCompleted = true });
            Todos.Add(new Todo() { Title = "Todo 4", IsCompleted = true });
        }


        // GET: api/Todos
        public List<Todo> Get()
        {
            return Todos;
        }

        // GET: api/Todos/5
        public Todo Get(int id)
        {
            return Todos.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/Todos
        public void Post(Todo val)
        {

            // Verify val is correct 
            //val = newtodotitle

            Todos.Add(val);
        }

        // PUT: api/Todos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Todos/5
        public void Delete(Todo val)
        {
            Todos.Remove(val);
        }
    }
}
