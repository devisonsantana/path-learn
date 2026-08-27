using TaskTracker.Models;

namespace TaskTracker.Services;

public interface ILogService
{
    IEnumerable<LogModel> GetHistory();
    IEnumerable<LogModel> GetHistory(int taskId);
    void RegisterCreated(int taskId, string title);
    void RegisterEdited(int taskId, string oldTitle, string newTitle);
    void RegisterMoved(int taskId, int oldPosition, int newPosition);
    void RegisterDone(int taskId, bool done);
    void RegisterDeleted(int taskId, string title);
}