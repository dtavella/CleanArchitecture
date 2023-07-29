using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public abstract class BaseAuditableEntityConfiguration<T, TI> : IEntityTypeConfiguration<T> where T : Auditable<TI>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CreatedDate).IsRequired();
            builder.Property(t => t.CreatedBy).IsRequired()
                                              .HasMaxLength(256);
            builder.Property(t => t.DeletedBy).HasMaxLength(256);
            builder.Property(t => t.DeletedDate);
            builder.Property(t => t.ModifiedBy).HasMaxLength(256);
        }
    }
}
