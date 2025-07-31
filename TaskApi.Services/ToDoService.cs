using Corzent_Dotnet_Bootcamp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public class ToDoService : IToDoService
    {
        // In-memory storage for ToDo items
        private readonly List<ToDos> _items;
        private int _nextId; // Tracks the next available ID

        public ToDoService()
        {
            // Initialize with some sample data
            _items = new List<ToDos>
            {
                new ToDos { Id = 1, Name = "Buy groceries", Description = "Milk, Bread, Eggs", IsCompleted = false, Priority = PriorityLevel.Medium },
                new ToDos { Id = 2, Name = "Clean the house", Description = "Vacuum and dust all rooms", IsCompleted = false, Priority = PriorityLevel.Low },
                new ToDos { Id = 3, Name = "Finish project", Description = "Complete the API project by Friday", IsCompleted = false, Priority = PriorityLevel.High }
            };

            // Set the next ID to be one more than the highest existing ID
            _nextId = _items.Max(x => x.Id) + 1;
        }

        public Task<List<ToDos>> GetAllAsync()
        {
            // Return all items
            return Task.FromResult(_items);
        }

        public Task<ToDos?> GetByIdAsync(int id)
        {
            // Find item by ID or return null if not found
            var item = _items.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
        }

        public Task<ToDos> CreateAsync(ToDos item)
        {
            // Assign a new ID and add to the list
            item.Id = _nextId++;
            _items.Add(item);
            return Task.FromResult(item);
        }

        public Task<bool> UpdateAsync(int id, ToDos item)
        {
            // Find the index of the item to update
            var index = _items.FindIndex(x => x.Id == id);
            if (index == -1) return Task.FromResult(false); // Not found

            // Preserve the ID and update the item
            item.Id = id;
            _items[index] = item;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            // Find the item to delete
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return Task.FromResult(false); // Not found

            // Remove the item
            _items.Remove(item);
            return Task.FromResult(true);
        }
    }
}