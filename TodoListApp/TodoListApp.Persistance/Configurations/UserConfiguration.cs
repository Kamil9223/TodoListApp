using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoListApp.Core.Domain;

namespace TodoListApp.Persistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Points)
                .IsRequired();
        }
    }
}
