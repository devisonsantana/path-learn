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
        var task = _repository.GetById(id);
        if (task is null)
            return false;

        _repository.Delete(task);
        _logService.RegisterDeleted(task.Id, task.Title);

        return true;
    }

    public bool Edit(int id, string newTitle)
    {
        var task = _repository.GetById(id);
        if (task is null)
            return false;

        string oldTitle = task.Title;
        task.Title = newTitle;

        _repository.Update(task);
        _logService.RegisterEdited(id, oldTitle, newTitle);

        return true;
    }

    public IEnumerable<TaskModel> GetAll() => _repository.GetAll();

    public bool Move(int id, int newPosition)
    {
        var task = _repository.GetById(id);
        if (task is null)
            return false;

        int count = GetAll().Count();
        newPosition = newPosition < 1 ? 1 : newPosition > count ? count : newPosition;

        if (task.Position == newPosition)
            return true;

        _repository.Move(task.Id, task.Position, newPosition);
        _logService.RegisterMoved(task.Id, task.Position, newPosition);

        return true;
    }

    public bool ToggleDone(int id)
    {
        var task = _repository.GetById(id);
        if (task is null)
            return false;

        task.Done = !task.Done;

        _repository.Update(task);
        _logService.RegisterDone(task.Id, task.Done);

        return true;
    }
}
