using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class DefaultContext2 : DbContext
    {
        public DefaultContext2(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}