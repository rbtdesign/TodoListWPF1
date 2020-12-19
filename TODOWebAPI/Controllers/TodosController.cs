using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODOWebAPI.DataAccess;
using TODOWebAPI.Models;

namespace TODOWebAPI.Controllers
{
    public class TodosController : ApiController
    {
        // You can precise Route with 
        // [Route("api/Todos/GetXXX")] // Apply on the following command, names don't have to match
        // [HttpGet] // Precise the type of command it accept
        // [Route("api/Todos/GetXXX/{userId:int"/{age:int})] // Add parameter


        // GET: api/Todos
        public List<TodoModel> Get()
        {

            //if (Todos == null)
            //{
            //    var message = string.Format("No todos found");

            //    // HttpResponseException allos us to still be able to return a strong typed model
            //    throw new HttpResponseException(
            //        Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            //}
            //else
            //{
            //    return Todos;
            //}

            TodoData data = new TodoData();

            var output = data.GetAllTodos();

            return output;


        }

        //GET: api/Todos/5
        public HttpResponseMessage Get(int id)
        {

            //var item = Todos.Where(x => x.Id == id).FirstOrDefault();

            TodoData data = new TodoData();

            var todo = data.GetTodoById(id);

            if (todo == null)
            {
                var message = string.Format("Product with id = {0} not found", id);
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, todo);
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


            try
            {
                TodoData data = new TodoData();
                int id = data.AddTodo(title);

                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Todos
        public HttpResponseMessage Put([FromBody] TodoModel todo)
        {

            try
            {
                TodoData data = new TodoData();
                
                data.UpdateTodo(todo);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        //DELETE: api/Todos/5
        public HttpResponseMessage Delete(int id)
        {
            //var isDeleted = Todos.Remove(Todos.Where(x => x.Id == id).FirstOrDefault());

            TodoData data = new TodoData();

            int isDeleted = data.DeleteTodoById(id);

            if (isDeleted > 0)
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                var message = string.Format("Todo {0} was not deleted", id);
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }



        }
    }
}






