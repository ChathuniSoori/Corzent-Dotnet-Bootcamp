using Microsoft.AspNetCore.Mvc;
using Corzent_Dotnet_Bootcamp.Models;
using Corzent_Dotnet_Bootcamp.Services;

namespace Corzent_Dotnet_Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoAppsController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        // Dependency Injection of ToDoService
        public ToDoAppsController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        // GET: api/ToDoApp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoAppClass>>> GetToDoItems()
        {
            var items = await _toDoService.GetAllAsync();
            return Ok(items);
        }

        // GET: api/ToDoApp/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoAppClass>> GetToDoItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound($"No ToDo item found with ID {id}");
            }

            return Ok(item);
        }

        // POST: api/ToDoApp
        [HttpPost]
        public async Task<ActionResult<ToDoAppClass>> CreateToDoItem(ToDoAppClass toDoItem)
        {
            if (toDoItem == null)
            {
                return BadRequest("Item data cannot be null.");
            }

            var createdItem = await _toDoService.CreateAsync(toDoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/ToDoApp/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItem(int id, ToDoAppClass toDoItem)
        {
            if (id <= 0 || toDoItem == null)
            {
                return BadRequest("Invalid data.");
            }

            var success = await _toDoService.UpdateAsync(id, toDoItem);
            if (!success)
            {
                return NotFound($"No ToDo item found with ID {id}");
            }

            return NoContent();
        }

        // DELETE: api/ToDoApp/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            var success = await _toDoService.DeleteAsync(id);
            if (!success)
            {
                return NotFound($"No ToDo item found with ID {id}");
            }

            return NoContent();
        }
    }
}
