using Core.Dtos;
using Core.Services.Implementatios;
using Core.Services.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FileTest
    {
        [Fact]
        public async Task ProcessFile()
        {
            // arrange
            var dtos = new List<DataFileDto>()
            {
                new DataFileDto
                {
                    Reg = 4,
                    Value = "Diego"
                },
                new DataFileDto
                {
                    Reg = 8,
                    Value = "Tavella"
                },
                new DataFileDto
                {
                    Reg = 9,
                    Value = "Tomas"
                },
                new DataFileDto
                {
                    Reg = 9,
                    Value = "Juan"
                },
            };

            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(q => q.GetDataFile()).ReturnsAsync(dtos);

            var processService = new ProcessService(fileServiceMock.Object);

            var dataResult = await processService.Process();


            dataResult.Count().Should().Be(3);
        }
    }
}
