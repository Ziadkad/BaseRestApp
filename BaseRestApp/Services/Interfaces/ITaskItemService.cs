using BaseRestApp.Dtos;
using BaseRestApp.Entities;

namespace BaseRestApp.Services.Interfaces;

public interface ITaskItemService
{
    Task<List<TaskItemDto>> GetAllTaskItems();
    Task<TaskItemDto?> GetTaskItem(Guid id);
    Task<TaskItemDto> CreateTaskItem(TaskItemCreateDto taskItemCreateDto);
    Task UpdateTaskItem(Guid id, TaskItemDto taskItemDto);
    Task RemoveTaskItem(Guid id);
}