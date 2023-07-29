using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ClassTimeConfiguration : BaseAuditableEntityConfiguration<ClassTime, int>
    {
        public override void Configure(EntityTypeBuilder<ClassTime> builder)
        {
            base.Configure(builder);

            builder.ToTable("ClassTimes");

            builder.Property(q => q.StartTime).IsRequired();
            builder.Property(q => q.EndTime).IsRequired();
            builder.Property(q => q.DayOfWeek).IsRequired();

            builder.HasOne(q => q.Course)
                   .WithMany(q => q.ClassTimes)
                   .HasForeignKey(q => q.CourseId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
