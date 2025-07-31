using Microsoft.AspNetCore.Mvc;        
using Corzent_Dotnet_Bootcamp.Services;
using TaskApi.Models;
namespace Corzent_Dotnet_Bootcamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoAppsController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoAppsController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDos>>> GetToDoItems()
        {
            var items = await _toDoService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDos>> GetToDoItem(int id)
        {
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"No ToDo item found with ID {id}");

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDos>> CreateToDoItem([FromBody] ToDos toDoItem)
        {
            if (toDoItem == null)
                return BadRequest("Item data cannot be null.");

            var createdItem = await _toDoService.CreateAsync(toDoItem);
            return CreatedAtAction(nameof(GetToDoItem), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDos>> UpdateToDoItem(int id, [FromBody] ToDos toDoItem)
        {
            if (toDoItem == null)
                return BadRequest("Invalid data.");

            var success = await _toDoService.UpdateAsync(id, toDoItem);
            if (!success)
                return NotFound($"No ToDo item found with ID {id}");

            // Return updated item with 200 OK
            var updatedItem = await _toDoService.GetByIdAsync(id);
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(int id)
        {
            var item = await _toDoService.GetByIdAsync(id);
            if (item == null)
                return NotFound($"No ToDo item found with ID {id}");

            var success = await _toDoService.DeleteAsync(id);
            if (!success)
                return NotFound($"No ToDo item found with ID {id}");

            return Ok(new { message = $"ToDo item with ID {id} deleted successfully." });
        }

    }
}
