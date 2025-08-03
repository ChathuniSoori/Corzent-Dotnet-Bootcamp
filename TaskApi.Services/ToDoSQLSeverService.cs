using Corzent_Dotnet_Bootcamp.Models;
using Corzent_Dotnet_Bootcamp.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskApi.Persistance;

namespace TaskApi.Services
{
    public class ToDoSQLSeverService : IToDoServiceRepository
    {
        private readonly ToDoDbContext _dbContext = new ToDoDbContext();
        public async Task<List<ToDos>> SearchAsync(string? name, string? category)
        {
            return await _dbContext.ToDos
                .Where(todo =>
                    (string.IsNullOrWhiteSpace(name) || todo.Name.ToLower().Contains(name.Trim().ToLower())) &&
                    (string.IsNullOrWhiteSpace(category) || todo.Category.ToLower() == category.Trim().ToLower()))
                .ToListAsync();
        }


        public async Task<List<ToDos>> GetAllAsync()
        {
            return await _dbContext.ToDos.ToListAsync();
        }

        public async Task<ToDos?> GetByIdAsync(int id)
        {
            return await _dbContext.ToDos.FindAsync(id);
        }

        public async Task<ToDos> CreateAsync(ToDos item)
        {
            _dbContext.ToDos.Add(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateAsync(int id, ToDos item)
        {
            var existingItem = await _dbContext.ToDos.FindAsync(id);
            if (existingItem == null) return false;

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.IsCompleted = item.IsCompleted;
            existingItem.Priority = item.Priority;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _dbContext.ToDos.FindAsync(id);
            if (item == null) return false;

            _dbContext.ToDos.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
