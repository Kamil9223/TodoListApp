using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoListApp.Core.Domain;

namespace TodoListApp.Persistance.Configurations
{
    public class SingleTaskConfiguration : IEntityTypeConfiguration<SingleTask>
    {
        public void Configure(EntityTypeBuilder<SingleTask> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(x => x.SingleTaskId);

            builder.Property(x => x.TaskName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasConversion(new EnumToNumberConverter<PriorityLevel, byte>())
                .HasDefaultValue(PriorityLevel.Low);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.HasOne(x => x.Board)
                .WithMany(x => x.Tasks);
        }
    }
}
