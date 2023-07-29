using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class Repository<TE, TI> : IRepository<TE, TI> where TE : EntityBase<TI>
    {
        protected readonly DbSet<TE> _dbSet;

        public Repository(DefaultContext context)
        {
            _dbSet = context.Set<TE>();
        }

        public async Task<TE> Add(TE entity)
        {
            var valueTask = await _dbSet.AddAsync(entity);
            return valueTask.Entity;
        }

        public async Task<bool> Any(Expression<Func<TE, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(TE entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TE> Get(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<TE>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                               .ToListAsync();
        }

        public void Update(TE entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<TProyected> GetProyected<TProyected>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TProyected>> proyection)
        {
            return await _dbSet.Where(predicate)
                               .Select(proyection)
                               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TProyected>> GetProyectedMany<TProyected>(Expression<Func<TE, bool>> predicate, Expression<Func<TE, TProyected>> proyection)
        {
            return await _dbSet.Where(predicate)
                               .Select(proyection)
                               .ToListAsync();
        }
    }
}
