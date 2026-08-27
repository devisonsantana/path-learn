namespace TaskTracker.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Position { get; set; }
    public bool Done { get; set; }
}