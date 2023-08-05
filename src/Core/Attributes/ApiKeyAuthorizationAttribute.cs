using Core.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Core.Attributes
{
    public class ApiKeyAuthorizationAttribute : Attribute, IAsyncAuthorizationFilter
    {
        const string _apikeyName = "api-key";
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var configuration = (IConfiguration)context.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            var apikey = configuration.GetValue<string>("api-key");
            if (!context.HttpContext.Request.Headers.TryGetValue(_apikeyName, out var value))
                throw new BusinessUnauthorizedException("ErrInvalidCredentials");

            if (value != apikey) throw new BusinessForbiddenException("ErrInvalidCredentials");

            await Task.CompletedTask;
        }
    }
}
