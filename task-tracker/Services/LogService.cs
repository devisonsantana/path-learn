using TaskTracker.Models;
using TaskTracker.Repositories;

namespace TaskTracker.Services;

public class LogService(ILogRepository repository) : ILogService
{
    private readonly ILogRepository _repository = repository;

    public IEnumerable<LogModel> GetHistory()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LogModel> GetHistory(int taskId)
    {
        throw new NotImplementedException();
    }

    public void RegisterCreated(int taskId, string title)
    {
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = $"Create a task '{title}'",
            ActionType = ActionType.Created,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
    }

    public void RegisterDeleted(int taskId, string title)
    {
        throw new NotImplementedException();
    }

    public void RegisterDone(int taskId, bool done)
    {
        throw new NotImplementedException();
    }

    public void RegisterEdited(int taskId, string oldTitle, string newTitle)
    {
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = $"Title changed from '{oldTitle}' to '{newTitle}'",
            ActionType = ActionType.Edited,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
    }

    public void RegisterMoved(int taskId, int oldPosition, int newPosition)
    {
        throw new NotImplementedException();
    }
}