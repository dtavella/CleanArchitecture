using AutoMapper;
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
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(StudentAddDto dto)
        {
            if (dto == null) throw new BusinessException("ErrDtoInvalid");
            if(string.IsNullOrWhiteSpace(dto.DocumentNumber)) throw new BusinessException("ErrDocumentNumberIsRequired");

            var studentRepository = _unitOfWork.GetRepository<Student, long>();
            if (await studentRepository.Any(q => q.DocumentNumber == dto.DocumentNumber)) 
                throw new BusinessException("ErrStudentAlreadyExists");

            var countyId = await _unitOfWork.Countries.GetCountryIdByCountryCode(dto.CountryCode);
            if (countyId == 0) throw new BusinessNotFoundException("ErrCountryCodeNotFound");

            var entity = _mapper.Map<Student>(dto);

            entity.CreatedDate = DateTime.UtcNow;
            entity.CreatedBy = "system";
            entity.CountryId = countyId;
            entity.RegistrationDate = DateTime.UtcNow;


            //var entity = new Student
            //{
            //    Name = dto.Name,
            //    LastName = dto.LastName,
            //    BirthDate = dto.BirthDate,
            //    DocumentNumber = dto.DocumentNumber,
            //    RegistrationDate = DateTime.UtcNow,
            //    CountryId = countyId,
            //    CreatedBy = "system",
            //    CreatedDate = DateTime.UtcNow,
            //};


            await studentRepository.Add(entity);
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

        public async Task Update(StudentEditDto dto)
        {
            if (dto == null) throw new BusinessException("ErrInvalidDto");
            if (string.IsNullOrWhiteSpace(dto.CountryCode)) throw new BusinessException("ErrCountryCodeIsRequired");

            // validar el resto

            var studentRepository = _unitOfWork.GetRepository<Student, long>();
            var student = await studentRepository.Get(dto.Id) ?? throw new BusinessNotFoundException("ErrStudentNotFound");
            var countryId = await _unitOfWork.Countries.GetCountryIdByCountryCode(dto.CountryCode);
            if (countryId == 0) throw new BusinessNotFoundException("ErrCountryCodeNotFound");

            student.DocumentNumber = dto.DocumentNumber;
            student.Name = dto.Name;
            student.LastName = dto.LastName;
            student.BirthDate = dto.BirthDate;
            student.CountryId = countryId;
            student.ModifiedBy = "system";

            studentRepository.Update(student);
            await _unitOfWork.Commit();
        }
    }
}
