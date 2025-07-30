using Corzent_Dotnet_Bootcamp.Models;
using System.Linq;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly List<ToDoAppClass> _toDoItems = new()
        {
            new ToDoAppClass { Id = 1, Name = "Task 1", Description = "First task", IsCompleted = false, Priority = PriorityLevel.Medium },
            new ToDoAppClass { Id = 2, Name = "Task 2", Description = "Second task", IsCompleted = true, Priority = PriorityLevel.High }
        };

        public async Task<IEnumerable<ToDoAppClass>> GetAllAsync()
        {
            return await Task.FromResult(_toDoItems);
        }

        public async Task<ToDoAppClass?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_toDoItems.FirstOrDefault(x => x.Id == id));
        }

        public async Task<ToDoAppClass> CreateAsync(ToDoAppClass toDoItem)
        {
            toDoItem.Id = _toDoItems.Max(x => x.Id) + 1; // Assign new Id
            _toDoItems.Add(toDoItem);
            return await Task.FromResult(toDoItem);
        }

        public async Task<bool> UpdateAsync(int id, ToDoAppClass toDoItem)
        {
            var existingItem = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (existingItem == null) return false;

            existingItem.Name = toDoItem.Name;
            existingItem.Description = toDoItem.Description;
            existingItem.IsCompleted = toDoItem.IsCompleted;
            existingItem.Priority = toDoItem.Priority;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = _toDoItems.FirstOrDefault(x => x.Id == id);
            if (item == null) return false;

            _toDoItems.Remove(item);
            return await Task.FromResult(true);
        }
    }
}
