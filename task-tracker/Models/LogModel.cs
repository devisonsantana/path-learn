namespace TaskTracker.Models;

public class LogModel
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public string ActionDescription { get; set; } = null!;
    public ActionType ActionType { get; set; }
    public DateTime ActionTime { get; set; }
}