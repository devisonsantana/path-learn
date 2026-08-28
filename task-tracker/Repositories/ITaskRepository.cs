using TaskTracker.Models;

namespace TaskTracker.Repositories;

public interface ITaskRepository
{
    IEnumerable<TaskModel> GetAll();
    TaskModel? GetById(int id);
    int GetMaxPosition();
    int Insert(TaskModel task);
    void Update(TaskModel task);
    void Delete(TaskModel task);
    void Move(int id, int from, int to);
}