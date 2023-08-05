using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface IAutheticationService
    {
        Task<string> GetToken(LoginDto dto);
    }
}
