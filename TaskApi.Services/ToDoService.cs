using Corzent_Dotnet_Bootcamp.Models;
using TaskApi.Models;

namespace Corzent_Dotnet_Bootcamp.Services
{
    public class ToDoService : IToDoService
    {
        private readonly List<ToDos> _items;
        private int _nextId;

        public ToDoService()
        {
            _items = new List<ToDos>
            {
                new ToDos { Id = 1, Name = "Buy groceries", Description = "Milk, Bread, Eggs", IsCompleted = false, Priority = PriorityLevel.Medium },
                new ToDos { Id = 2, Name = "Clean the house", Description = "Vacuum and dust all rooms", IsCompleted = false, Priority = PriorityLevel.Low },
                new ToDos { Id = 3, Name = "Finish project", Description = "Complete the API project by Friday", IsCompleted = false, Priority = PriorityLevel.High }
            };

            _nextId = _items.Max(x => x.Id) + 1;
        }

        public Task<List<ToDos>> GetAllAsync()
        {
            return Task.FromResult(_items);
        }

        public Task<ToDos?> GetByIdAsync(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(item);
        }

        public Task<ToDos> CreateAsync(ToDos item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return Task.FromResult(item);
        }

        public Task<bool> UpdateAsync(int id, ToDos item)
        {
            var index = _items.FindIndex(x => x.Id == id);
            if (index == -1) return Task.FromResult(false);

            item.Id = id;
            _items[index] = item;
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return Task.FromResult(false);

            _items.Remove(item);
            return Task.FromResult(true);
        }
    }
}
