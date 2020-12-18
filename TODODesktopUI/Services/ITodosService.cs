using System.Collections.Generic;
using System.Threading.Tasks;
using TODODesktopUI.Models;

namespace TODODesktopUI.Services

{
    public interface ITodosService
    {
        Task<List<Todo>> GetAll();
        Task<Todo> Get(int id);
        Task Create(string todoTitle);
        Task Update(Todo todo);
        Task Delete(int id);
    }
}