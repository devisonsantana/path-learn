using Microsoft.Data.Sqlite;

namespace TaskTracker.Extension;

public static class SqliteExtensions
{
    public static void Migrate(this SqliteConnection connection)
    {
        using var transaction = connection.BeginTransaction();

        var createTasksIfNotExists = connection.CreateCommand();
        createTasksIfNotExists.Transaction = transaction;
        createTasksIfNotExists.CommandText = """
            CREATE TABLE IF NOT EXISTS Tasks (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title VARCHAR(255) NOT NULL,
                Position INTEGER NOT NULL,
                Done INTEGER NOT NULL DEFAULT 0
            );
        """;
        createTasksIfNotExists.ExecuteNonQuery();

        var createLogsIfNotExists = connection.CreateCommand();
        createLogsIfNotExists.Transaction = transaction;
        createLogsIfNotExists.CommandText = """
            CREATE TABLE IF NOT EXISTS Logs (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                TaskId INTEGER NOT NULL,
                ActionDescription VARCHAR(255) NOT NULL,
                ActionType INTEGER NOT NULL,
                ActionTime DATETIME NOT NULL,
                FOREIGN KEY (TaskId) REFERENCES Tasks(Id)
            );
        """;
        createLogsIfNotExists.ExecuteNonQuery();

        transaction.Commit();
    }
}