using Microsoft.EntityFrameworkCore;
using TodoListApp.Core.Domain;

namespace TodoListApp.Persistance.Context
{
    public class TodoTasksContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TasksBoard> Boards { get; set; }
        public DbSet<TaskDetails> TasksDetails { get; set; }
        public DbSet<SingleTask> Tasks { get; set; }

        public TodoTasksContext() { }

        public TodoTasksContext(DbContextOptions<TodoTasksContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoTasksContext).Assembly);
        }
    }
}
