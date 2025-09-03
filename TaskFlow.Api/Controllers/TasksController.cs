using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repo;

    public TasksController(ITaskRepository repo) => _repo = repo;

    [HttpGet]
    public ActionResult<IEnumerable<TaskViewDto>> GetAll()
    {
        var items = _repo.GetAll().Select(MapToView);
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public ActionResult<TaskViewDto> GetById(int id)
    {
        var item = _repo.GetById(id);
        return item is null ? NotFound() : Ok(MapToView(item));
    }

    [HttpPost]
    public ActionResult<TaskViewDto> Create([FromBody] TaskCreateDto dto)
    {
        var entity = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description
        };

        var created = _repo.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, MapToView(created));
    }

    [HttpPut("{id:int}")]
    public ActionResult<TaskViewDto> Update(int id, [FromBody] TaskUpdateDto dto)
    {
        var task = _repo.GetById(id);
        if (task is null)
            return NotFound();

        if (!Enum.TryParse<TaskFlow.Domain.Entities.TaskStatus>(dto.Status, true, out var status))
            return BadRequest("Invalid status. Use Pending, InProgress or Done.");

        task.Title = dto.Title;
        task.Description = dto.Description;
        task.Status = status;
        task.UpdatedAt = DateTime.UtcNow;

        _repo.Update(task);
        return Ok(MapToView(task));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleteSuccess = _repo.Delete(id);
        return deleteSuccess ? NoContent() : NotFound();
    }

    private static TaskViewDto MapToView(TaskItem item) => new(item.Id, item.Title, item.Description, item.Status.ToString(), item.CreatedAt, item.UpdatedAt);
}