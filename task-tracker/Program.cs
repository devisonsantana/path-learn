using Microsoft.Data.Sqlite;
using TaskTracker.Extension;
using TaskTracker.Repositories;
using TaskTracker.Services;

namespace TaskTracker;

public class Program
{
    static bool Running = true;
    public static void Main()
    {
        using SqliteConnection connection = new("Data Source=Data/data.db");

        connection.Open();
        connection.Migrate();

        ILogRepository logRepository = new LogRepository(connection);
        ITaskRepository taskRepository = new TaskRepository(connection);
        ILogService logService = new LogService(logRepository);
        ITaskService taskService = new TaskService(taskRepository, logService);

        Console.WriteLine("Task Tracker - type 'help' to see the available commands.");

        while (Running)
        {
            Console.Write("\n> ");
            string? rawInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(rawInput))
                continue;

            string[] inputValues = rawInput.Split(' ', 2);
            string command = inputValues[0].ToLower();
            string options = inputValues.Length > 1 ? inputValues[1] : "";

            switch (command)
            {
                case "list":
                    List(taskService);
                    break;
                case "add":
                    if (!string.IsNullOrWhiteSpace(options))
                        Add(taskService, options.Trim());
                    else
                        Console.WriteLine("Missing argument. Usage: add <title>");
                    break;
                case "edit":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        string[] args = options.Trim().Split(' ', 2);
                        if (args.Length > 1)
                        {
                            string title = args[1];
                            if (int.TryParse(args[0], out int id))
                                Edit(taskService, id, title);
                            else
                                Console.WriteLine("Invalid id. Usage: edit <id> <title>");
                            break;
                        }
                    }
                    Console.WriteLine("Missing argument. Usage: edit <id> <title>");
                    break;
                case "done":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        if (int.TryParse(options.Trim(), out int id))
                            Done(taskService, id);
                        else
                            Console.WriteLine("Invalid id. Usage: done <id>");
                        break;
                    }
                    Console.WriteLine("Missing argument. Usage: done <id>");
                    break;
                case "mv":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        string[] args = options.Trim().Split(' ', 2);
                        if (args.Length > 1)
                        {
                            if (int.TryParse(args[0], out int id) && int.TryParse(args[1], out int newPosition))
                                Move(taskService, id, newPosition);
                            else
                                Console.WriteLine("Invalid id. Usage: mv <id> <position>");
                            break;
                        }
                    }
                    Console.WriteLine("Missing argument. Usage: mv <id> <position>");
                    break;
                case "del":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        if (int.TryParse(options.Trim(), out int id))
                            Delete(taskService, id);
                        else
                            Console.WriteLine("Invalid id. Usage: del <id>");
                        break;
                    }
                    Console.WriteLine("Missing argument. Usage: del <id>");
                    break;
                case "logs":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        if (int.TryParse(options.Trim(), out int id))
                            Logs(logService, id);
                        else
                            Console.WriteLine("Invalid id. Usage: logs <id>");
                        break;
                    }
                    Logs(logService);
                    break;
                case "help":
                    Help();
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    Console.WriteLine($"Unknown command: '{command}'. Type 'help' to see the available commands.");
                    break;
            }
        }
    }
    static void List(ITaskService service)
    {
        var tasks = service.GetAll();

        if (!tasks.Any())
        {
            Console.WriteLine("No tasks found. Use 'add <title>' to create one.");
            return;
        }

        foreach (var task in tasks)
        {
            string status = task.Done ? "[x]" : "[ ]";
            Console.WriteLine($"{status} #{task.Id} (pos {task.Position}) {task.Title}");
        }
    }
    static void Add(ITaskService service, string title)
    {
        var task = service.Add(title);
        Console.WriteLine($"Task added: [ ] #{task.Id} {task.Title}");
    }
    static void Edit(ITaskService service, int id, string title)
    {
        bool success = service.Edit(id, title);

        if (success)
            Console.WriteLine($"Task #{id} updated.");
        else
            Console.WriteLine($"Task #{id} not found.");
    }
    static void Done(ITaskService service, int id)
    {
        bool success = service.ToggleDone(id);

        if (success)
            Console.WriteLine($"Task #{id} status toggled.");
        else
            Console.WriteLine($"Task #{id} not found.");
    }
    static void Move(ITaskService service, int id, int newPosition)
    {
        int success = service.Move(id, newPosition);

        if (success == 1)
            Console.WriteLine($"Task #{id} moved.");
        else if (success == 0)
            Console.WriteLine($"Task #{id} not modified.");
        else
            Console.WriteLine($"Task #{id} not found.");

    }
    static void Delete(ITaskService service, int id)
    {
        bool success = service.Delete(id);

        if (success)
            Console.WriteLine($"Task #{id} deleted.");
        else
            Console.WriteLine($"Task #{id} not found.");
    }
    static void Logs(ILogService service)
    {
        var logs = service.GetHistory();

        if (!logs.Any())
        {
            Console.WriteLine("No logs found.");
            return;
        }

        foreach (var log in logs)
            Console.WriteLine($"#{log.TaskId} | {log.ActionDescription} | {log.ActionType} | {log.ActionTime}");
    }
    static void Logs(ILogService service, int id)
    {
        var logs = service.GetHistory(id);

        if (!logs.Any())
        {
            Console.WriteLine("No logs found.");
            return;
        }

        Console.WriteLine($"Showing {logs.Count()} log(s) for task #{id}.");
        foreach (var log in logs)
            Console.WriteLine($"#{log.TaskId} | {log.ActionDescription} | {log.ActionType} | {log.ActionTime}");
    }
    static void Help()
    {
        Console.WriteLine(
        """
        Available commands:

        COMMAND    ARGUMENTS       DESCRIPTION
        list                       List all tasks
        add        <title>         Add a new task
        edit       <id> <title>    Edit the title of an existing task
        done       <id>            Mark/unmark a task as done
        mv         <id> <pos>      Move a task to a new position
        del        <id>            Delete a task
        logs       [id]            Show history (all tasks, or a specific task)
        help                       Show this list of commands
        exit                       Exit the application
        """
        );
    }
    static void Exit()
    {
        Console.WriteLine("Bye!");
        Running = false;
    }
}