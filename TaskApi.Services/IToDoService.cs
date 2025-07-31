using Corzent_Dotnet_Bootcamp.Models;
using TaskApi.Models;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public interface IToDoService
    {
        Task<List<ToDos>> GetAllAsync();
        Task<ToDos?> GetByIdAsync(int id);
        Task<ToDos> CreateAsync(ToDos item);
        Task<bool> UpdateAsync(int id, ToDos item);
        Task<bool> DeleteAsync(int id);
        
        
    }
}
