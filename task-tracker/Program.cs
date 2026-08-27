using TaskTracker.Repositories;
using TaskTracker.Services;

namespace TaskTracker;

public class Program
{
    static bool Running = true;
    public static void Main()
    {
        ITaskRepository taskRepository = new TaskRepository();
        ITaskService taskService = new TaskService(taskRepository);

        Console.WriteLine("Task Tracker - type 'help' to see the available commands.");

        while (Running)
        {
            Console.Write("\n> ");
            string? rawInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(rawInput))
            {
                continue;
            }

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
                case "del":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        if (int.TryParse(options.Trim(), out int id))
                            Delete(taskService, id);
                        else
                            Console.WriteLine("Invalid id. Usage: del <id>");
                        break;
                    }
                    Console.WriteLine("Argumment is missing to del command");
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
    }
    static void Add(ITaskService service, string title)
    {
    }
    static void Edit(ITaskService service, int id, string title)
    {
    }
    static void Delete(ITaskService service, int id)
    {
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
        del        <id>            Delete a task
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