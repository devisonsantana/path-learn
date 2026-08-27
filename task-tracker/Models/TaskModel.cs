namespace TaskTracker.Models;

class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Position { get; set; }
    public bool Done { get; set; }
}