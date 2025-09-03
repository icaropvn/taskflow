using TaskFlow.Domain.Entities;

namespace TaskFlow.Domain.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAll();
    TaskItem? GetById(int id);
    TaskItem Add(TaskItem item);
    bool Update(TaskItem item);
    bool Delete(int id);
}