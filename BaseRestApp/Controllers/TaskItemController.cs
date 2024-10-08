using BaseRestApp.Dtos;
using BaseRestApp.Entities;
using BaseRestApp.Exceptions;
using BaseRestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseRestApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskItemController : ControllerBase
{
    private readonly TaskItemService _taskItemService;

    public TaskItemController(TaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTaskItems() 
    {
        try
        {
            return Ok(await _taskItemService.GetAllTaskItems());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskItem(Guid id)
    {
        try
        {
            return Ok(await _taskItemService.GetTaskItem(id));
        }
        catch (TaskItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTaskItem([FromBody] TaskItemCreateDto taskItemCreateDto)
    {
        try
        {
            TaskItemDto taskItemDto = await _taskItemService.CreateTaskItem(taskItemCreateDto);
            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItemDto.Id }, taskItemDto);
        }
        catch (SomethingWentWrongException e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskItem(Guid id, [FromBody] TaskItemDto taskItemDto)
    {
        try
        {
            await _taskItemService.UpdateTaskItem(id,taskItemDto);
            return NoContent();
        }
        catch (TaskItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (SomethingWentWrongException e)
        {
            return StatusCode(500, e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveTaskItem(Guid id)
    {
        try
        {
            await _taskItemService.RemoveTaskItem(id);
            return NoContent();
        }
        catch (TaskItemNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (SomethingWentWrongException e)
        {
            return StatusCode(500, e.Message);
        }
    }
}