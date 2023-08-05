using Core.Dtos;
using Core.Entities;
using Core.Exceptions;
using Core.Repositories;
using Core.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Services.Implementatios
{
    public class AutheticationService : IAutheticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public AutheticationService(IUnitOfWork unitOfWork, ISecurityService securityService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task<string> GetToken(LoginDto dto)
        {
            var userRepository = _unitOfWork.GetRepository<User, long>();
            var hash = await userRepository.GetProyected(q => q.Email == dto.Email, p => p.Password) ?? throw new BusinessNotFoundException("ErrUserNotFound");

            if (!_securityService.Verify(dto.Pasword, hash)) throw new BusinessException("ErrInvalidEmailOrPassword");

            return GenerateTokenJwt(dto.Email);
        }

        private string GenerateTokenJwt(string email)
        {
            var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Audience:Secret")));
            var tokenDescription = new SecurityTokenDescriptor
            {
                //Issuer = _configuration.GetValue<string>("Audience:Iss")
                //Audience = _configuration.GetValue<string>("Audience:Aud")
                Expires = DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("Audience:Experies")),
                SigningCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, email),
                        new Claim("test diego", "resultado")
                    }
               )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);
        }
    }
}
