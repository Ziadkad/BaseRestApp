namespace BaseRestApp.Exceptions;

public class TaskItemNotFoundException : Exception
{
    public TaskItemNotFoundException(Guid id) : base($"TaskItem with Id : {id} not found")
    {
    }
}