namespace Core.Repositories
{
    public interface ICountryRepository
    {
        Task<int> GetCountryIdByCountryCode(string countryCode);
    }
}
