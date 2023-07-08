using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses")
                   .HasKey(q => q.Id);

            builder.Property(q => q.Code).IsRequired().HasMaxLength(32);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(128);

        }
    }
}
