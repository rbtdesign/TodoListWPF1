using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Helpers;
using TODODesktopUI.Models;

namespace TODODesktopUI.Services
{
    public class TodosService : ITodosService
    {

        private string url = "api/todos/";

        public async Task<List<Todo>> GetAll()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Todo> todolist = await response.Content.ReadAsAsync<List<Todo>>();

                    return todolist;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Todo> Get(int id)
        {

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    Todo todo = await response.Content.ReadAsAsync<Todo>();

                    return todo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task Create(string todoTitle)
        {

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todoTitle);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpResponseMessage response = 
            await ApiHelper.ApiClient.PostAsync(url, stringContent);
        }

        public async Task Update(Todo todo)
        {

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todo);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            await ApiHelper.ApiClient.PutAsync(url, stringContent);
        }

        public async Task Delete(int id)
        {
            await ApiHelper.ApiClient.DeleteAsync(url + id);

        }
    }
}
