using System.Collections.Concurrent;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Repositories;

namespace TaskFlow.Infrastructure.Repositories;

public class InMemoryRepository : ITaskRepository
{
    private readonly ConcurrentDictionary<int, TaskItem> _items = new();
    private int _idSeed = 0;

    public IEnumerable<TaskItem> GetAll() => _items.Values.OrderBy(i => i.Id);

    public TaskItem? GetById(int id) => _items.TryGetValue(id, out var it) ? it : null;

    public TaskItem Add(TaskItem item)
    {
        var id = Interlocked.Increment(ref _idSeed);
        item.Id = id;
        _items[id] = item;
        return item;
    }

    public bool Update(TaskItem item)
    {
        if (!_items.ContainsKey(item.Id))
            return false;

        _items[item.Id] = item;
        return true;
    }

    public bool Delete(int id) => _items.TryRemove(id, out _);
}