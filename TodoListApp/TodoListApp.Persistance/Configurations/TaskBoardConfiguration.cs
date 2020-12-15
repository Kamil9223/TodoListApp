using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.Core.Domain;

namespace TodoListApp.Persistance.Configurations
{
    public class TaskBoardConfiguration : IEntityTypeConfiguration<TasksBoard>
    {
        public void Configure(EntityTypeBuilder<TasksBoard> builder)
        {
            builder.HasKey(x => x.TasksBoardId);

            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Boards);
        }
    }
}
