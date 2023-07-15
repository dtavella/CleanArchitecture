using Core.Entities;
using Core.Repositories;
using Core.Services.Implementatios;
using FluentAssertions;
using Moq;

namespace Tests
{
    public class UnitTest1
    {
        internal class RepoTest : IStudentRepository
        {
            public List<Student> GetAll()
            {
                return new List<Student> { };
            }
        }

        [Fact]
        public void Test1()
        {
            var repoMock = new Mock<IStudentRepository>();
            repoMock.Setup(q => q.GetAll()).Returns(new List<Student>());
            //var service = new StudentService(repoMock.Object);
            //var dtos = service.GetAll();

            //dtos.Count.Should().Be(0);
        }
    }
}