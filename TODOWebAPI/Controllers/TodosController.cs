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

        private readonly TodoData _todoData = new TodoData();

        [HttpGet]
        [Route("api/Todos")]
        public HttpResponseMessage Get()
        {
            List<TodoDto> todolist = _todoData.GetAllTodos();

            if (todolist == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, todolist);
        }

        [HttpGet]
        [Route("api/Todos/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            TodoDto todo = _todoData.GetTodoById(id);

            if (todo == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
    
            return Request.CreateResponse(HttpStatusCode.OK, todo);
      
        }

        [HttpPost]
        [Route("api/Todos")]
        public HttpResponseMessage Post([FromBody] string todoTitle)
        {
            if (String.IsNullOrEmpty(todoTitle))
            {
                var message = string.Format("Title of todo cannot be null or empty ");
                HttpError err = new HttpError(message);

                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }

            try
            {
                int id = _todoData.AddTodo(todoTitle);

                return Request.CreateResponse(HttpStatusCode.Created, id);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("api/Todos")]
        public HttpResponseMessage Put([FromBody] TodoDto todo)
        {
                
            int res = _todoData.UpdateTodo(todo);


            switch (res)
            {
                case 0:
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                case -1:
                    var message = string.Format($"Something went wrong when updating the record {0}", todo.Id);
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, err);
                default:
                    return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }

        [HttpDelete]
        [Route("api/Todos/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {

            int res = _todoData.DeleteTodoById(id);

            switch (res)
            {
                case 0 :
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                case -1:
                    var message = string.Format($"Something went wrong when deleting the record {0}", id);
                    HttpError err = new HttpError(message);
                    return Request.CreateResponse(HttpStatusCode.BadRequest, err);
                default:
                    return Request.CreateResponse(HttpStatusCode.NoContent);
            }


        }
    }
}






