using TaskTracker.Models;
using TaskTracker.Repositories;

namespace TaskTracker.Services;

public class TaskService(ITaskRepository repository) : ITaskService
{
    private readonly ITaskRepository _repository = repository;

    public TaskModel Add(string title)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }

    public bool Edit(int id, string title)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TaskModel> GetAll()
    {
        var tasks = _repository.GetAll();
        return tasks;
    }

    public bool Move(int id, int newPosition)
    {
        throw new NotImplementedException();
    }

    public bool ToggleDone(int id)
    {
        throw new NotImplementedException();
    }
}
