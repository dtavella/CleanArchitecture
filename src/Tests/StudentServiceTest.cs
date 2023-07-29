using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Mapper;
using Core.Repositories;
using Core.Services.Implementatios;
using FluentAssertions;
using Moq;
using System.Linq.Expressions;

namespace Tests
{
    public class StudentServiceTest
    {
        [Fact]
        public async Task AddStudent_WithNonExistingDNI_ShouldSuccess()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });

            var iunitofwork = new Mock<IUnitOfWork>();
            var istudentRepository = new Mock<IRepository<Student, long>>();
            var icountryRepository = new Mock<ICountryRepository>();

            iunitofwork.Setup(q => q.GetRepository<Student, long>()).Returns(istudentRepository.Object);
            iunitofwork.Setup(q => q.Countries).Returns(icountryRepository.Object);
            istudentRepository.Setup(q => q.Any(It.IsAny<Expression<Func<Student, bool>>>())).ReturnsAsync(false);
            icountryRepository.Setup(q => q.GetCountryIdByCountryCode(It.IsAny<string>())).ReturnsAsync(0);

            var service = new StudentService(iunitofwork.Object, mapperConfiguration.CreateMapper());

            var dto = new StudentAddDto
            {
                Name = "Test",
                LastName = "Test",
                BirthDate = DateTime.Now,
                DocumentNumber = "1232232323"
            };

            await service.Invoking(async x => await x.Add(dto))
                         .Should()
                         .ThrowAsync<BusinessNotFoundException>()
                         .WithMessage("ErrCountryCodeNotFound");
        }
    }
}
