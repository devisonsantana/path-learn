using Microsoft.Data.Sqlite;
using TaskTracker.Models;

namespace TaskTracker.Repositories;

public class TaskRepository(SqliteConnection connection) : ITaskRepository
{
    private readonly SqliteConnection _connection = connection;

    public void Delete(TaskModel task)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TaskModel> GetAll()
    {
        var tasks = new List<TaskModel>();

        var select = _connection.CreateCommand();
        select.CommandText = """
            SELECT
                Id,
                Title,
                Position,
                Done
            FROM Tasks
                ORDER BY Position ASC;
        """;
        using var reader = select.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            int position = reader.GetInt32(2);
            bool done = reader.GetBoolean(3);

            var task = new TaskModel
            {
                Id = id,
                Title = title,
                Position = position,
                Done = done
            };
            tasks.Add(task);
        }
        return tasks;
    }

    public TaskModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public int GetMaxPosition()
    {
        throw new NotImplementedException();
    }

    public int Insert(TaskModel task)
    {
        throw new NotImplementedException();
    }

    public void Move(int id, int from, int to)
    {
        throw new NotImplementedException();
    }

    public void Update(TaskModel task)
    {
        throw new NotImplementedException();
    }
}