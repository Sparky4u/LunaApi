using LunaApi.DAL.Data.DTO;
using LunaApi.DAL.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using LunaApi.Common.Enums;

namespace LunaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto taskDto)
        {
            var userId = GetUserId();
            var task = await _taskService.CreateTask(userId, taskDto.Title, taskDto.Description, taskDto.DueDate, taskDto.Status, taskDto.Priority);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks([FromQuery] Status? status = null, [FromQuery] DateTime? dueDate = null, [FromQuery] Priority? priority = null)
        {
            var userId = GetUserId();
            var tasks = await _taskService.GetTasks(userId, status, dueDate, priority);
            return Ok(tasks);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var userId = GetUserId();
            var task = await _taskService.GetTaskById(userId, id);

            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskUpdateDto taskDto)
        {
            var userId = GetUserId();
            var task = await _taskService.UpdateTask(userId, id, taskDto.Title, taskDto.Description, taskDto.DueDate, taskDto.Status, taskDto.Priority);

            if (task == null)
            {
                return NotFound("Task not found");
            }

            return Ok(task);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var userId = GetUserId();
            var result = await _taskService.DeleteTask(userId, id);

            if (!result)
            {
                return NotFound("Task not found");
            }

            return Ok("Task deleted successfully");
        }

        private Guid GetUserId()
        {
            var identifier = User.FindFirst(ClaimTypes.NameIdentifier);
            if (identifier != null && Guid.TryParse(identifier.Value, out Guid userId))
            {
                return userId;
            }
            throw new UnauthorizedAccessException("User ID claim is missing or invalid.");
        }
    }
}
