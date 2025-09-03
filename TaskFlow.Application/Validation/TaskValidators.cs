using FluentValidation;

namespace TaskFlow.Application.DTOs;

public class TaskCreateDtoValidator : AbstractValidator<TaskCreateDto>
{
    public TaskCreateDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);
    }
}

public class TaskUpdateDtoValidator : AbstractValidator<TaskUpdateDto>
{
    public TaskUpdateDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).MaximumLength(500);

        RuleFor(x => x.Status).NotEmpty()
            .Must(s => new[] { "Pending", "InProgress", "Done" }
                .Contains(s, StringComparer.OrdinalIgnoreCase))
            .WithMessage("Status must be Pending, InProgress or Done.");
    }
}