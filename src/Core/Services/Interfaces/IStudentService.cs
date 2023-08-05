using Core.Dtos;
using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> Get(long id);
        Task<IList<StudentDto>> GetAll();
        Task<StudentAddDto> Add(StudentAddDto entity);
        Task Update(StudentEditDto dto);
        Task Delete(Student entity);
    }
}
