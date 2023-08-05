using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolesPermissions");

            builder.HasKey(q => new { q.RoleId, q.PermissionId });

            builder.HasOne(q => q.Role)
                   .WithMany(q => q.RolePermissions)
                   .HasForeignKey(q => q.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(q => q.Permission)
                   .WithMany(q => q.RolePermissions)
                   .HasForeignKey(q => q.PermissionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
