using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DbSet<Country> _dbSet;

        public CountryRepository(DefaultContext context)
        {
            _dbSet = context.Set<Country>();
        }

        public async Task<int> GetCountryIdByCountryCode(string countryCode)
        {
            return await _dbSet.Where(q => q.Code == countryCode)
                               .Select(q => q.Id)
                               .FirstOrDefaultAsync();
        }

        public async Task<Country> Add(Country entity)
        {
            var valueTask = await _dbSet.AddAsync(entity);
            return valueTask.Entity;
        }

        public async Task<bool> Any(Expression<Func<Country, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public void Delete(Country entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<Country> Get(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<Country>> GetAll()
        {
            return await _dbSet.AsNoTracking()
                               .ToListAsync();
        }

        public void Update(Country entity)
        {
            _dbSet.Update(entity);
        }
    }
}
