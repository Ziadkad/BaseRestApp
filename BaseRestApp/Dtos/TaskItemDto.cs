namespace BaseRestApp.Dtos;

public class TaskItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }
}