using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public ICourseRepository Courses => throw new NotImplementedException();

        public ICountryRepository Countries => new CountryRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public IRepository<TE, TI> GetRepository<TE, TI>() where TE : EntityBase<TI>
        {
            return new Repository<TE, TI>(_context);
        }
    }
}
