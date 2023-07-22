using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface IFileService
    {
        Task<IList<DataFileDto>> GetDataFile();
    }
}
