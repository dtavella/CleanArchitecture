using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries")
                   .HasKey(x => x.Id);

            builder.Property(q => q.Name).IsRequired().HasMaxLength(128);
            builder.Property(q => q.Code).IsRequired().HasMaxLength(8);
        }
    }
}
