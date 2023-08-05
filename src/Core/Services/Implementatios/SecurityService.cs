using Core.Services.Interfaces;

namespace Core.Services.Implementatios
{
    public class SecurityService : ISecurityService
    {
        public bool Verify(string password, string hash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch { return false;  }
        }
    }
}
