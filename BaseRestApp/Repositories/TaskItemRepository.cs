using BaseRestApp.Data;
using BaseRestApp.Entities;
using BaseRestApp.Repositories.Interfaces;

namespace BaseRestApp.Repositories;

public class TaskItemRepository : Repository<TaskItem> , ITaskItemRepository
{
    public TaskItemRepository(AppDbContext db) : base(db)
    {
    }
}