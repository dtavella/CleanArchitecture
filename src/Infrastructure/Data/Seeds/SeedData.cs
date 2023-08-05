using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seeds
{
    public class SeedData
    {
        public static void Seeds(ModelBuilder modelBuilder)
        {
            SeedCountries(modelBuilder);
            SeedUsers(modelBuilder);
            SeedPermissions(modelBuilder);
            SeedRoles(modelBuilder);
            SeedRolesPermissions(modelBuilder);
        }

        public static void SeedCountries(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData
            (
               // new Country { Id = (int)Core.Enums.Country.Argentina, Code = "ARG", Name = Core.Enums.Country.Argentina.ToString() },
                new Country { Id = (int)Core.Enums.Country.Brasil, Code = "BRA", Name = Core.Enums.Country.Brasil.ToString() }
            );
        }

        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
            (
                new User { Id = 1, Email = "test@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("12345678"), RoleId = (int)Core.Enums.Role.Administrator, CreatedBy = "system", CreatedDate = DateTime.UtcNow }
            );
        }

        public static void SeedPermissions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData
            (
                new Permission { Id = (int)Core.Enums.Permission.AddStudent, Code = "AddStudent", Description = Core.Enums.Permission.AddStudent.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.UpdateStudent, Code = "UpdateStudent", Description = Core.Enums.Permission.UpdateStudent.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.DeleteStudent, Code = "DeleteStudent", Description = Core.Enums.Permission.DeleteStudent.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.AddCourse, Code = "AddCourse", Description = Core.Enums.Permission.AddCourse.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.UpdateCourse, Code = "UpdateCourse", Description = Core.Enums.Permission.UpdateCourse.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.DeleteCourse, Code = "DeleteCourse", Description = Core.Enums.Permission.DeleteCourse.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.AddStudentToCourse, Code = "AddStudentToCourse", Description = Core.Enums.Permission.AddStudentToCourse.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.UpdateStudentToCourse, Code = "UpdateStudentToCourse", Description = Core.Enums.Permission.UpdateStudentToCourse.ToString() },
                new Permission { Id = (int)Core.Enums.Permission.DeleteStudentToCourse, Code = "DeleteStudentToCourse", Description = Core.Enums.Permission.DeleteStudentToCourse.ToString() }
            );
        }

        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData
            (
                new Role { Id = (int)Core.Enums.Role.Administrator, Code = "Administrator", Description = Core.Enums.Role.Administrator.ToString() },
                new Role { Id = (int)Core.Enums.Role.Teacher, Code = "Teacher", Description = Core.Enums.Role.Teacher.ToString() },
                new Role { Id = (int)Core.Enums.Role.Student, Code = "Student", Description = Core.Enums.Role.Student.ToString() }
            );
        }

        public static void SeedRolesPermissions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolePermission>().HasData
            (
                // Administrator
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.AddStudent },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.UpdateStudent },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.DeleteStudent },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.AddCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.UpdateCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.DeleteCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.AddStudentToCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.UpdateStudentToCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Administrator, PermissionId = (int)Core.Enums.Permission.DeleteStudentToCourse },

                // Student
                new RolePermission { RoleId = (int)Core.Enums.Role.Student, PermissionId = (int)Core.Enums.Permission.AddStudentToCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Student, PermissionId = (int)Core.Enums.Permission.UpdateStudentToCourse },
                new RolePermission { RoleId = (int)Core.Enums.Role.Student, PermissionId = (int)Core.Enums.Permission.DeleteStudentToCourse }
            );
        }
    }
}
