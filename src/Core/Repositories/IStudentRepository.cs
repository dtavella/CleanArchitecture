using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Repositories
{
    public interface IStudentRepository
    {
        Task<IList<Student>> GetAll();
        Task<Student> Get(long id);
        void Update(Student entity);
        Task<Student> Add(Student entity);
        void Delete(Student entity);
        Task<bool> Any(Expression<Func<Student, bool>> predicate);
    }

}
