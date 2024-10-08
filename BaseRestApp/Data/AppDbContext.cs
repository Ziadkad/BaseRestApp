using BaseRestApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseRestApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<TaskItem> TaskItems { get; set; }
}