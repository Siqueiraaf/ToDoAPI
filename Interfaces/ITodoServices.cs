using TodoAPi.Models;
using TodoAPI.Contracts;

namespace TodoAPi.Interfaces
{
     public interface ITodoServices
     {
         Task<IEnumerable<Todo>> GetAllAsync();
         Task<Todo> GetByIdAsync(Guid id);
         Task CreateTodoAsync(CreateTodoRequestDTO request);
         Task UpdateTodoAsync(Guid id, UpdateTodoRequestDTO request);
         Task DeleteTodoAsync(Guid id);
     }
}