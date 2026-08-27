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

        Console.WriteLine("[WELCOME MESSAGE]");

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
                        Console.WriteLine("Argumment is missing to add command");
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
                                Console.WriteLine("Provide a valid number for id argumment");
                            break;
                        }
                    }
                    Console.WriteLine("Argumment is missing to edit command");
                    break;
                case "del":
                    if (!string.IsNullOrWhiteSpace(options))
                    {
                        if (int.TryParse(options.Trim(), out int id))
                            Delete(taskService, id);
                        else
                            Console.WriteLine("Provide a valid number for id argumment");
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
                    Console.WriteLine($"Error: Command {command} not found...");
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
        [COMMAND HEADER]

        [COMMAND]        [ARGUMENTS]        [DESCRITPION]
        list
        add
        edit
        del
        help
        exit
        """
        );
    }
    static void Exit()
    {
        Console.WriteLine("Bye...");
        Running = false;
    }
}