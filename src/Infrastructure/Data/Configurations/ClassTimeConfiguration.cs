using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ClassTimeConfiguration : IEntityTypeConfiguration<ClassTime>
    {
        public void Configure(EntityTypeBuilder<ClassTime> builder)
        {
            builder.ToTable("ClassTimes")
                   .HasKey(x => x.Id);

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
