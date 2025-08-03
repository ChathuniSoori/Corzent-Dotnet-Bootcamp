using Microsoft.AspNetCore.Mvc;
using Corzent_Dotnet_Bootcamp.Services;
using Corzent_Dotnet_Bootcamp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Corzent_Dotnet_Bootcamp.Controllers
{
    [Route("api/[controller]")] // Base route: api/ToDoApps
    [ApiController]
    public class ToDoAppsController : ControllerBase
    {
        private readonly IToDoServiceRepository _toDoService;

        // Dependency injection of the service
        public ToDoAppsController(IToDoServiceRepository toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: api/ToDoApps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDos>>> GetToDoItems()
        {
            // Get all items from service
            var items = await _toDoService.GetAllAsync();
            return Ok(items); // 200 OK with items
        }

        // GET: api/ToDoApps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDos>> GetToDoItem(int id)
        {
            // Get item by ID
            var item = await _toDoService.GetByIdAsync(id);

            // Return 404 if not found
            if (item == null)
                return NotFound($"No ToDo item found with ID {id}");

            return Ok(item); // 200 OK with the item
        }

        // POST: api/ToDoApps
        [HttpPost]
        public async Task<ActionResult<ToDos>> CreateToDoItem([FromBody] ToDos toDoItem)
        {
            if (toDoItem == null)
                return BadRequest("Item data cannot be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdItem = await _toDoService.CreateAsync(toDoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/ToDoApps/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ToDos>> UpdateToDoItem(int id, [FromBody] ToDos toDoItem)
        {
            // Validate input
            if (toDoItem == null)
                return BadRequest("Invalid data.");

            // Try to update
            var success = await _toDoService.UpdateAsync(id, toDoItem);
            if (!success)
                return NotFound($"No ToDo item found with ID {id}");

            // Return updated item
            var updatedItem = await _toDoService.GetByIdAsync(id);
            return Ok(updatedItem);
        }

        // DELETE: api/ToDoApps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            // Check if item exists
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"No ToDo item found with ID {id}");

            // Try to delete
            var success = await _toDoService.DeleteAsync(id);
            if (!success)
                return NotFound($"No ToDo item found with ID {id}");

            // Return success message
            return Ok(new { message = $"ToDo item with ID {id} deleted successfully." });
        }
    }
}