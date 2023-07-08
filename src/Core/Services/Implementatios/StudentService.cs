using Core.Dtos;
using Core.Repositories;
using Core.Services.Interfaces;

namespace Core.Services.Implementatios
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository) 
        {
            _studentRepository = studentRepository;
        }

        public List<StudentDto> GetAll()
        {
            return null;
            //var entities = _studentRepository.GetAll();
            //return entities.Select(dtos => new StudentDto { Id = dtos.Id, Name = dtos.Name }).ToList();
        }
    }
}
