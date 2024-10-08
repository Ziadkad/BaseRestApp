using System.ComponentModel.DataAnnotations;

namespace BaseRestApp.Entities;

public class TaskItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? TaskName { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}