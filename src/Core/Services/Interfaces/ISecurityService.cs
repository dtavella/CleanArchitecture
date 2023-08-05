namespace Core.Services.Interfaces
{
    public interface ISecurityService
    {
        bool Verify(string password, string hasg);
    }
}
