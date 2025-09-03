namespace TaskFlow.Domain.Entities;

public enum TaskStatus { Pending = -1, InProgress = 0, Done = 1 }

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? Description { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}