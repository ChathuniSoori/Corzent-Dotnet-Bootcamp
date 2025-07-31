using Corzent_Dotnet_Bootcamp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public interface IToDoService
    {
        // Get all ToDo items
        Task<List<ToDos>> GetAllAsync();

        // Get a single ToDo item by ID
        Task<ToDos?> GetByIdAsync(int id);

        // Create a new ToDo item
        Task<ToDos> CreateAsync(ToDos item);

        // Update an existing ToDo item
        Task<bool> UpdateAsync(int id, ToDos item);

        // Delete a ToDo item
        Task<bool> DeleteAsync(int id);
    }
}