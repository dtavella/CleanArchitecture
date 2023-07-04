using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDto> GetAll();
    }
}
