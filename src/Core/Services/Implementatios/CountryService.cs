using Microsoft.Extensions.Logging;

namespace Core.Services.Implementatios
{
    public class CountryService
    {
        private readonly ILogger<CountryService> _logger;

        public CountryService(ILogger<CountryService> logger)
        {
            _logger = logger;
        }
    }
}