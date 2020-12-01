using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Helpers;
using TODODesktopUI.Library;

namespace TODODesktopUI.Models
{
    public class TodosProcessor
    {

        public static async Task<List<Todo>> GetAll()
        {
            string url = "api/todos/";

            using (HttpResponseMessage response = await ApiService.ApiClient.GetAsync(url))
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

        public static async Task<Todo> Create(string todoTitle)
        {
            string url = "api/todos/";

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todoTitle);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiService.ApiClient.PostAsync(url, stringContent))
            {

                if (response.IsSuccessStatusCode)
                {
                    Todo newTodo = await response.Content.ReadAsAsync<Todo>();

                    return newTodo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<List<Todo>> Update(Todo todo)
        {
            string url = "api/todos/";

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todo);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiService.ApiClient.PutAsync(url, stringContent) )
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





        public static async Task<bool> Delete(int id)
        {
            string url = $"api/todos/{id}";

            using (HttpResponseMessage response = await ApiService.ApiClient.DeleteAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
