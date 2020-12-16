using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.Core.Domain;

namespace TodoListApp.Persistance.Configurations
{
    public class TaskDetailsConfiguration : IEntityTypeConfiguration<TaskDetails>
    {
        public void Configure(EntityTypeBuilder<TaskDetails> builder)
        {
            builder.ToTable("TaskDetails");

            builder.HasKey(x => x.TaskDetailsId);

            builder.Property(x => x.TaskDetailName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);
        }
    }
}
