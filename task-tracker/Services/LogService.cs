using TaskTracker.Models;
using TaskTracker.Repositories;

namespace TaskTracker.Services;

public class LogService(ILogRepository repository) : ILogService
{
    private readonly ILogRepository _repository = repository;

    public IEnumerable<LogModel> GetHistory() => _repository.GetAll();

    public IEnumerable<LogModel> GetHistory(int taskId) => _repository.GetByTaskId(taskId);

    public void RegisterCreated(int taskId, string title)
    {
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = $"Created task '{title}'",
            ActionType = ActionType.Created,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
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
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = $"Moved task #{taskId} from (pos {oldPosition}) to (pos {newPosition})",
            ActionType = ActionType.Moved,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
    }

    public void RegisterDone(int taskId, bool done)
    {
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = done ? "Marked as done" : "Marked as not done",
            ActionType = done ? ActionType.Completed : ActionType.Reopened,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
    }

    public void RegisterDeleted(int taskId, string title)
    {
        var log = new LogModel
        {
            TaskId = taskId,
            ActionDescription = $"Deleted task '{title}'",
            ActionType = ActionType.Deleted,
            ActionTime = DateTime.Now
        };
        _repository.Insert(log);
    }
}