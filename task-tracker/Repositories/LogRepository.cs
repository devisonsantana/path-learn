using Microsoft.Data.Sqlite;
using TaskTracker.Models;

namespace TaskTracker.Repositories;

public class LogRepository(SqliteConnection connection) : ILogRepository
{
    private readonly SqliteConnection _connection = connection;

    public IEnumerable<LogModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LogModel> GetByTaskId(int taskId)
    {
        throw new NotImplementedException();
    }

    public void Insert(LogModel log)
    {
        var insert = _connection.CreateCommand();
        insert.CommandText = """
            INSERT INTO Logs
                (TaskId, ActionDescription, ActionType, ActionTime)
            VALUES
                (@taskId, @actionDescription, @actionType, @actionTime);
        """;
        insert.Parameters.AddWithValue("@taskId", log.TaskId);
        insert.Parameters.AddWithValue("@actionDescription", log.ActionDescription);
        insert.Parameters.AddWithValue("@actionType", log.ActionType);
        insert.Parameters.AddWithValue("@actionTime", log.ActionTime);

        insert.ExecuteNonQuery();
    }
}