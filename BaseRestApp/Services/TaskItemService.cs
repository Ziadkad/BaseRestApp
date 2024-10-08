using AutoMapper;
using BaseRestApp.Dtos;
using BaseRestApp.Entities;
using BaseRestApp.Exceptions;
using BaseRestApp.Repositories.Interfaces;
using BaseRestApp.Services.Interfaces;

namespace BaseRestApp.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IMapper _mapper;

    public TaskItemService(ITaskItemRepository taskItemRepository, IMapper mapper)
    {
        _taskItemRepository = taskItemRepository;
        _mapper = mapper;
    }

    public async Task<List<TaskItemDto>> GetAllTaskItems()
    {
        return _mapper.Map<List<TaskItemDto>>(await _taskItemRepository.GetAllAsNoTracking());
    }

    public async Task<TaskItemDto?> GetTaskItem(Guid id)
    {
        TaskItem? taskItem = await _taskItemRepository.GetAsNoTracking(ti => ti.Id == id) ?? throw new TaskItemNotFoundException(id);;
        return _mapper.Map<TaskItemDto>(taskItem);
    }

    public async Task<TaskItemDto> CreateTaskItem(TaskItemCreateDto taskItemCreateDto)
    {
        TaskItem taskItem = _mapper.Map<TaskItem>(taskItemCreateDto);
        if (await _taskItemRepository.CreateAsync(taskItem))
        {
            return _mapper.Map<TaskItemDto>(taskItem);
        }
        throw new SomethingWentWrongException();
    }

    public async Task UpdateTaskItem(Guid id, TaskItemDto taskItemDto)
    {
        if (id != taskItemDto.Id)
        {
            throw new Exception("Ids don't match");
        }
        TaskItem taskItemCheck = await _taskItemRepository.GetAsNoTracking(ti => ti.Id == id) ?? throw new TaskItemNotFoundException(id);
        TaskItem taskItem = _mapper.Map<TaskItem>(taskItemDto);
        if (await _taskItemRepository.UpdateAsync(taskItem))
        {
            return;
        }
        throw new SomethingWentWrongException();
    }

    public async Task RemoveTaskItem(Guid id)
    {
        TaskItem taskItem = await _taskItemRepository.GetAsNoTracking(ti => ti.Id == id) ?? throw new TaskItemNotFoundException(id);
        if (await _taskItemRepository.RemoveAsync(taskItem))
        {
            return;
        }
        throw new SomethingWentWrongException();
    }
}