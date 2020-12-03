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

            if (Todos == null)
            {
                var message = string.Format("No todos found");

                // HttpResponseException allos us to still be able to return a strong typed model
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            else
            {
                return Todos;
            }
        }

        //GET: api/Todos/5
        public HttpResponseMessage Get(int id)
        {

            var item = Todos.Where(x => x.Id == id).FirstOrDefault();

            if (item == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
        }

        // POST: api/Todos
        public HttpResponseMessage Post([FromBody] string title)
        {
            // Logic to verify title

            if (String.IsNullOrEmpty(title))
            {
                var message = string.Format("Title of todo cannot be null or empty ");
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                // Logic to add new todo to fake db
                count++; // Increase counter for fake ID
                Todo todo = new Todo() { Title = title, Id = count };
                Todos.Add(todo); // Add to fake DB

                return Request.CreateResponse(HttpStatusCode.OK, todo);
            }
        }

        // PUT: api/Todos
        public List<Todo> Put([FromBody] Todo todo)
        {

            var editedTodo = Todos.FirstOrDefault(t => t.Id == todo.Id);

            if (editedTodo == default)
            {
                var message = string.Format("Todo with id = {0} was not updated", todo.Id);

                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            else
            {
                editedTodo.Title = todo.Title;

                return Todos;
            }

        }

        // DELETE: api/Todos/5
        public HttpResponseMessage Delete(int id)
        {
            var isDeleted = Todos.Remove(Todos.Where(x => x.Id == id).FirstOrDefault());

            if (isDeleted)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                var message = string.Format("Todo with id = {0} was not deleted", id);
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }

        }
    }
}
