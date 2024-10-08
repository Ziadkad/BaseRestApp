namespace BaseRestApp.Dtos;

public class TaskItemDto
{
    public Guid Id { get; set; }
    public string? TaskName { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }
}