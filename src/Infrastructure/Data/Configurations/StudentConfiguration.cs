using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students")
                   .HasKey(q => q.Id);

            builder.Property(q => q.LastName)
                   .IsRequired()
                   .HasMaxLength(32);

            builder.Property(q => q.Name).IsRequired().HasMaxLength(128);
            builder.Property(q => q.DocumentNumber).IsRequired().HasMaxLength(24);
            builder.Property(q => q.CreatedBy).IsRequired().HasMaxLength(128);
            builder.Property(q => q.CreatedDate).IsRequired();
            builder.Property(q => q.RegistrationDate).IsRequired();
            builder.Property(q => q.BirthDate);

            builder.HasOne(q => q.Country)
                   .WithMany()
                   .HasForeignKey(q => q.CountryId)
                   .OnDelete(DeleteBehavior.NoAction);


            //builder.HasMany(q => q.Courses)
            //       .WithMany(q => q.Students);

            builder.HasMany(q => q.Courses)
                   .WithMany(q => q.Students)
                   .UsingEntity<CourseStudent>(q => q.HasOne(t => t.Course)
                                                     .WithMany()
                                                     .HasForeignKey(q => q.CourseId),
                                               q => q.HasOne(t => t.Student)
                                                     .WithMany()
                                                     .HasForeignKey(t => t.StudentId),
                                               q => q.ToTable("CoursesStudents"));

        }
    }
}
