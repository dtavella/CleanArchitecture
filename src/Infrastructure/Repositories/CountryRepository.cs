using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DefaultContext _context;
        private readonly DbSet<Country> _dbSet;

        public CountryRepository(DefaultContext context)
        {
            _context = context;
            _dbSet = context.Set<Country>();
        }

        public async Task<int> GetCountryIdByCountryCode(string countryCode)
        {
            return await _dbSet.Where(q => q.Code == countryCode)
                               .Select(q => q.Id)
                               .FirstOrDefaultAsync();
        }
    }
}
