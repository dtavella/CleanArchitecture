namespace Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Commit();

        IStudentRepository Students { get; }
        ICourseRepository Courses { get; }
        ICountryRepository Countries { get; }
    }
}
