using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DefaultContext _context;
        private readonly DbSet<Student> _dbSet;

        public StudentRepository(DefaultContext context)
        {
            _context = context;
            _dbSet = _context.Set<Student>();
        }
        public async Task<Student> Add(Student entity)
        {
            var valueTask = await _dbSet.AddAsync(entity);
            return valueTask.Entity;
        }

        public async Task<bool> Any(Expression<Func<Student, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(Student entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<Student> Get(long id)
        {
            return await _dbSet.FindAsync(id);            
        }

        public async Task<IList<Student>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                               .ToListAsync();
        }

        public void Update(Student entity)
        {
            _dbSet.Update(entity);
        }
    }
}
