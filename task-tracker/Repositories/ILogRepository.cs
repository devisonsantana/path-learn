using TaskTracker.Models;

namespace TaskTracker.Repositories;

public interface ILogRepository
{
    IEnumerable<LogModel> GetAll();
    IEnumerable<LogModel> GetByTaskId(int taskId);
    void Insert(LogModel log);
}