namespace TaskTracker;

public class Program
{
    static bool Running = true;
    public static void Main()
    {
        Console.WriteLine("[WELCOME MESSAGE]");

        while (Running)
        {
            Console.Write("> ");
            string? rawInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(rawInput))
            {
                continue;
            }

            string[] inputValues = rawInput.Split(' ', 2);
            string command = inputValues[0].ToLower();

            switch (command)
            {

                // TODO: OTHER COMMANDS HERE

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
    static void Help()
    {
        // TODO: LIST ALL COMMANDS
        Console.WriteLine("[COMMANDS WILL BE HERE]");
    }
    static void Exit()
    {
        Console.WriteLine("Bye...");
        Running = false;
    }
}