using Corzent_Dotnet_Bootcamp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Persistance;



namespace TaskApi.Persistance
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDos> ToDos { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }

        public ToDoDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=TaskDb;Integrated Security=True;TrustServerCertificate=True;\r\n";
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
    new Author
    {
        AuthorId = 1,
        Name = "Admin"
    }
);
            modelBuilder.Entity<ToDos>().HasData(new ToDos
            {
                Id = 1,
                Name = "Buy groceries-DB",
                Description = "Milk, Bread, Eggs",
                IsCompleted = false,
                Priority = PriorityLevel.Medium,
                Category="home todos",
                AuthorId = 1,
            });
        }
    }
}
