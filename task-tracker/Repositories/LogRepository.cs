using Microsoft.Data.Sqlite;
using TaskTracker.Models;

namespace TaskTracker.Repositories;

public class LogRepository(SqliteConnection connection) : ILogRepository
{
    private readonly SqliteConnection _connection = connection;

    public IEnumerable<LogModel> GetAll()
    {
        var logs = new List<LogModel>();

        var select = _connection.CreateCommand();
        select.CommandText = """
            SELECT
                Id,
                TaskId,
                ActionDescription,
                ActionType,
                ActionTime
            FROM Logs;
        """;

        using var reader = select.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int taskId = reader.GetInt32(1);
            string actionDescription = reader.GetString(2);
            ActionType actionType = (ActionType)reader.GetInt32(3);
            DateTime actionTime = reader.GetDateTime(4);

            var log = new LogModel
            {
                Id = id,
                TaskId = taskId,
                ActionDescription = actionDescription,
                ActionType = actionType,
                ActionTime = actionTime
            };
            logs.Add(log);
        }
        return logs;
    }

    public IEnumerable<LogModel> GetByTaskId(int taskId)
    {
        var logs = new List<LogModel>();

        var select = _connection.CreateCommand();
        select.CommandText = """
            SELECT
                Id,
                TaskId,
                ActionDescription,
                ActionType,
                ActionTime
            FROM Logs
            WHERE TaskId = @taskId;
        """;
        select.Parameters.AddWithValue("@taskId", taskId);

        using var reader = select.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            int taskIdDb = reader.GetInt32(1);
            string actionDescription = reader.GetString(2);
            ActionType actionType = (ActionType)reader.GetInt32(3);
            DateTime actionTime = reader.GetDateTime(4);

            var log = new LogModel
            {
                Id = id,
                TaskId = taskIdDb,
                ActionDescription = actionDescription,
                ActionType = actionType,
                ActionTime = actionTime
            };
            logs.Add(log);
        }
        return logs;
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