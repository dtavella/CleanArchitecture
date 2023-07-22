using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Core.Services.Interfaces;

namespace Core.Services.Implementatios
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(StudentAddDto dto)
        {
            if (dto == null) throw new BusinessException("ErrDtoInvalid");
            if(string.IsNullOrWhiteSpace(dto.DocumentNumber)) throw new BusinessException("ErrDocumentNumberIsRequired");

            if (await _unitOfWork.Students.Any(q => q.DocumentNumber == dto.DocumentNumber)) 
                throw new BusinessException("ErrStudentAlreadyExists");

            var countyId = await _unitOfWork.Countries.GetCountryIdByCountryCode(dto.CountryCode);
            if (countyId == 0) throw new BusinessNotFoundException("ErrCountryCodeNotFound");

            var entity = new Student
            {
                Name = dto.Name,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
                DocumentNumber = dto.DocumentNumber,
                RegistrationDate = DateTime.UtcNow,
                CountryId = countyId,
                CreatedBy = "system",
                DeletedBy = "system",
                CreatedDate = DateTime.UtcNow,
            };
            await _unitOfWork.Students.Add(entity);
            await _unitOfWork.Commit();
        }

        public Task Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<StudentDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
