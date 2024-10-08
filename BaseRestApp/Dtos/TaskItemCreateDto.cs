namespace BaseRestApp.Dtos;

public class TaskItemCreateDto
{
    public string? TaskName { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }
}