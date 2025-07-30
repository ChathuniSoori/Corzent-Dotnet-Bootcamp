using Corzent_Dotnet_Bootcamp.Models;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoAppClass>> GetAllAsync();
        Task<ToDoAppClass?> GetByIdAsync(int id);
        Task<ToDoAppClass> CreateAsync(ToDoAppClass toDoItem);
        Task<bool> UpdateAsync(int id, ToDoAppClass toDoItem);
        Task<bool> DeleteAsync(int id);
    }
}
