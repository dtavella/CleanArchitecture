using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CourseConfiguration : BaseAuditableEntityConfiguration<Course, int>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.ToTable("Courses");

            builder.Property(q => q.Code).IsRequired().HasMaxLength(32);
            builder.Property(q => q.Name).IsRequired().HasMaxLength(128);

        }
    }
}
