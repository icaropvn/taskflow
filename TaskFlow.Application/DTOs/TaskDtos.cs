namespace TaskFlow.Application.DTOs;

public record TaskCreateDto(string Title, string? Description);
public record TaskUpdateDto(string Title, string? Description, string Status);
public record TaskViewDto(int Id, string Title, string? Description, string Status, DateTime CreatedAt, DateTime? UpdatedAt);