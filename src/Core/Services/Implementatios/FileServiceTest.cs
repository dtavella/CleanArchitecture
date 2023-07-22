using Core.Dtos;
using Core.Services.Interfaces;

namespace Core.Services.Implementatios
{
    public class FileServiceTest : IFileService
    {
        public async Task<IList<DataFileDto>> GetDataFile()
        {
            var dtos = new List<DataFileDto>()
            {
                new DataFileDto
                {
                    Reg = 1,
                    Value = "A"
                },
                new DataFileDto
                {
                    Reg = 2,
                    Value = "B"
                },
            };

            await Task.CompletedTask;

            return dtos;
        }
    }
}
