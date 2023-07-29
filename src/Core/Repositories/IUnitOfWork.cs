using Core.Entities;

namespace Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit();

        ICourseRepository Courses { get; }
        ICountryRepository Countries { get; }

        IRepository<TE, TI> GetRepository<TE, TI>() where TE : EntityBase<TI>;
    }
}
