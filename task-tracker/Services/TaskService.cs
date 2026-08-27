using TaskTracker.Models;
using TaskTracker.Repositories;

namespace TaskTracker.Services;

public class TaskService(ITaskRepository repository, ILogService service) : ITaskService
{
    private readonly ITaskRepository _repository = repository;
    private readonly ILogService _logService = service;

    public TaskModel Add(string title)
    {
        int newPosition = _repository.GetMaxPosition() + 1;
        var task = new TaskModel
        {
            Title = title,
            Position = newPosition,
            Done = false
        };
        task.Id = _repository.Insert(task);

        _logService.RegisterCreated(task.Id, title);

        return task;
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public bool Edit(int id, string title)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TaskModel> GetAll() => _repository.GetAll();

    public bool Move(int id, int newPosition)
    {
        throw new NotImplementedException();
    }

    public bool ToggleDone(int id)
    {
        throw new NotImplementedException();
    }
}
