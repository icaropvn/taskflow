using FluentValidation;
using FluentValidation.AspNetCore;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Repositories;
using TaskFlow.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<TaskCreateDtoValidator>();

// Repository in memory
builder.Services.AddSingleton<ITaskRepository, InMemoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();