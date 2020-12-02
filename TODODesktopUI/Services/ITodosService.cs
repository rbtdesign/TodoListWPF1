using System.Collections.Generic;
using System.Threading.Tasks;
using TODODesktopUI.Library;

namespace TODODesktopUI.Services

{
    public interface ITodosService
    {
        Task<Todo> Create(string todoTitle);
        Task<bool> Delete(int id);
        Task<List<Todo>> GetAll();
        Task<List<Todo>> Update(Todo todo);
    }
}