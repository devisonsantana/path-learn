using TaskTracker.Repositories;

namespace TaskTracker.Services;

public class TaskService(ITaskRepository repository) : ITaskService
{
    private readonly ITaskRepository _repository = repository;
}
