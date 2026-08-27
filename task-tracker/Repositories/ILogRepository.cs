using TaskTracker.Models;

namespace TaskTracker.Repositories;

public interface ILogRepository
{
    IEnumerable<LogModel> GetAll();
    IEnumerable<LogModel> GetByTaskId(int taskId);
    int Insert(LogModel log);
}