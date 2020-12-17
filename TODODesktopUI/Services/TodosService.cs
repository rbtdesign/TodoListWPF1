﻿using Newtonsoft.Json;
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

        public async Task<List<Todo>> GetAll()
        {
            string url = "api/todos/";

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
            string url = "api/todos/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
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

        public async Task<int> Create(string todoTitle)
        {
            string url = "api/todos/";

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todoTitle);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, stringContent))
            {

                if (response.IsSuccessStatusCode)
                {
                    int id = await response.Content.ReadAsAsync<int>();

                    return id;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<bool> Update(Todo todo)
        {
            string url = "api/todos/";

            // Convert string to HttpContent
            string json = JsonConvert.SerializeObject(todo);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, stringContent))
            {

                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsAsync<List<Todo>>();

                    return true;
                }
                else
                {
                    // throw new Exception(response.ReasonPhrase); Find a better way to deal with error
                    return false;
                }
            }
        }

        public async Task<bool> Delete(int id)
        {
            string url = $"api/todos/{id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
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
