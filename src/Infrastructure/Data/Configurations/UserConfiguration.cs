using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UserConfiguration : BaseAuditableEntityConfiguration<User, long>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");
            builder.Property(u => u.Password).IsRequired().HasMaxLength(256);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(128);

            builder.HasOne(u => u.Role)
                   .WithMany()
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
