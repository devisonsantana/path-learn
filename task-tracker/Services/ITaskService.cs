using TaskTracker.Models;

namespace TaskTracker.Services;

public interface ITaskService
{
    IEnumerable<TaskModel> GetAll();
    TaskModel Add(string title);
    bool Edit(int id, string title);
    bool Delete(int id);
    bool Move(int id, int newPosition);
    bool ToggleDone(int id);
}