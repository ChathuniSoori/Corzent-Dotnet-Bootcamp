using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corzent_Dotnet_Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoAppController : ControllerBase
    {
        // GET: api/ToDoApp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoAppClass>>> GetToDoItems()
        {
            // Simulate fetching data from a database or service
            var items = new List<ToDoAppClass>
            {
                new ToDoAppClass { Name = "Task 1", Description = "Description for Task 1", IsCompleted = false },
                new ToDoAppClass { Name = "Task 2", Description = "Description for Task 2", IsCompleted = true }
            };
            return Ok(items);
        }
        //GET : api/ToDoApp/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoAppClass>> GetToDoItem(int id)
        {
            // Simulate fetching a single item by ID
            var item = new ToDoAppClass { Name = "Task 1", Description = "Description for Task 1", IsCompleted = false };
            if (id <= 0)
            {
                return NotFound();
            }
            return Ok(item);
        }
        // POST: api/ToDoApp
        [HttpPost]
        public async Task<ActionResult<ToDoAppClass>> CreateToDoItem(ToDoAppClass toDoItem)
        {
            // Simulate saving the item to a database or service
            if (toDoItem == null)
            {
                return BadRequest("Invalid item data.");
            }
            // Normally, you would save the item and return the created item with its ID
            return CreatedAtAction(nameof(GetToDoItem), new { id = 1 }, toDoItem);
        }
        // PUT: api/ToDoApp/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, ToDoAppClass toDoItem)
        {
            // Simulate updating the item in a database or service
            if (id <= 0 || toDoItem == null)
            {
                return BadRequest("Invalid item data.");
            }
            // Normally, you would update the item and return a success status
            return NoContent();
        }
        // DELETE: api/ToDoApp/{id}
        [HttpDelete("{id}")]    
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            // Simulate deleting the item from a database or service
            if (id <= 0)
            {
                return NotFound();
            }
            // Normally, you would delete the item and return a success status
            return NoContent();
        }

    }
}
