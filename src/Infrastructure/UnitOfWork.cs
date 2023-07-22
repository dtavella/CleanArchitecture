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

        public IStudentRepository Students => new StudentRepository(_context);

        public ICourseRepository Courses => throw new NotImplementedException();

        public ICountryRepository Countries => new CountryRepository(_context);

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
