using System.Collections.Generic;
using TODOWebAPI.Models;

namespace TODOWebAPI.DataAccess
{
    public interface ITodoData
    {
        int AddTodo(string title);
        int DeleteTodoById(int id);
        List<TodoDto> GetAllTodos();
        TodoDto GetTodoById(int id);
        int UpdateTodo(TodoDto Todo);
    }
}