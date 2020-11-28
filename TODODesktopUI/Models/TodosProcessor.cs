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
        public static async Task<Todo> LoadTodo(int id = 2)
        {
            string url = $"api/todos/{id}";

            using(HttpResponseMessage response = await ApiService.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    Todo todo = await response.Content.ReadAsAsync<Todo>();

                    return todo;
                } else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
