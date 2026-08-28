using Microsoft.Data.Sqlite;
using TaskTracker.Models;

namespace TaskTracker.Repositories;

public class TaskRepository(SqliteConnection connection) : ITaskRepository
{
    private readonly SqliteConnection _connection = connection;

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

    public TaskModel? GetById(int taskId)
    {
        var select = _connection.CreateCommand();
        select.CommandText = """
            SELECT
                Id,
                Title,
                Position,
                Done
            FROM Tasks
            WHERE Id = @id;
        """;
        select.Parameters.AddWithValue("@id", taskId);

        using var reader = select.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            int position = reader.GetInt32(2);
            bool done = reader.GetBoolean(3);

            return new TaskModel
            {
                Id = id,
                Title = title,
                Position = position,
                Done = done
            };
        }
        return null;
    }

    public int GetMaxPosition()
    {
        var select = _connection.CreateCommand();
        select.CommandText = """
            SELECT MAX(Position) FROM Tasks;
        """;

        var result = select.ExecuteScalar();

        return result is DBNull or null ? 0 : Convert.ToInt32(result);
    }

    public int Insert(TaskModel task)
    {
        using var transaction = _connection.BeginTransaction();

        var insert = _connection.CreateCommand();
        insert.Transaction = transaction;
        insert.CommandText = """
            INSERT INTO Tasks
                (Title, Position, Done)
            VALUES
                (@title, @position, @done);
        """;
        insert.Parameters.AddWithValue("@title", task.Title);
        insert.Parameters.AddWithValue("@position", task.Position);
        insert.Parameters.AddWithValue("@done", task.Done);

        insert.ExecuteNonQuery();

        var selectId = _connection.CreateCommand();
        selectId.Transaction = transaction;
        selectId.CommandText = "SELECT last_insert_rowid();";

        var result = selectId.ExecuteScalar();

        transaction.Commit();

        return Convert.ToInt32(result);
    }

    public void Update(TaskModel task)
    {
        var update = _connection.CreateCommand();
        update.CommandText = """
            UPDATE Tasks
                SET
                    Title = @title,
                    Done = @done
            WHERE Id = @id;
        """;
        update.Parameters.AddWithValue("@title", task.Title);
        update.Parameters.AddWithValue("@done", task.Done);
        update.Parameters.AddWithValue("@id", task.Id);

        update.ExecuteNonQuery();
    }

    public void Move(int id, int from, int to)
    {
        using var transaction = _connection.BeginTransaction();

        var update = _connection.CreateCommand();
        update.Transaction = transaction;

        if (from < to)
            update.CommandText = """
                UPDATE Tasks
                    SET Position = Position - 1
                WHERE Position > @from AND Position <= @to;
            """;
        else
            update.CommandText = """
                UPDATE Tasks
                    SET Position = Position + 1
                WHERE Position < @from AND Position >= @to;
            """;
        update.Parameters.AddWithValue("@from", from);
        update.Parameters.AddWithValue("@to", to);

        update.ExecuteNonQuery();

        var moveTask = _connection.CreateCommand();
        moveTask.Transaction = transaction;

        moveTask.CommandText = "UPDATE Tasks SET Position = @to WHERE Id = @id;";
        moveTask.Parameters.AddWithValue("@to", to);
        moveTask.Parameters.AddWithValue("@id", id);

        moveTask.ExecuteNonQuery();

        transaction.Commit();
    }

    public void Delete(TaskModel task)
    {
        using var transaction = _connection.BeginTransaction();

        var delete = _connection.CreateCommand();
        delete.Transaction = transaction;
        delete.CommandText = """
            DELETE FROM Tasks WHERE Id = @id;
        """;
        delete.Parameters.AddWithValue("@id", task.Id);

        delete.ExecuteNonQuery();

        var updatePositions = _connection.CreateCommand();
        updatePositions.Transaction = transaction;
        updatePositions.CommandText = """
            UPDATE Tasks
                SET Position = Position - 1
            WHERE Position > @position;
        """;
        updatePositions.Parameters.AddWithValue("@position", task.Position);

        updatePositions.ExecuteNonQuery();

        transaction.Commit();
    }
}