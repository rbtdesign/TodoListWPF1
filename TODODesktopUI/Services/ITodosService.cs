using System.Collections.Generic;
using System.Threading.Tasks;
using TODODesktopUI.Models;

namespace TODODesktopUI.Services

{
    public interface ITodosService
    {
        Task<List<Todo>> GetAll();
        Task<Todo> Get(int id);
        Task<int> Create(string todoTitle);
        Task<List<Todo>> Update(Todo todo);
        Task<bool> Delete(int id);
    }
}