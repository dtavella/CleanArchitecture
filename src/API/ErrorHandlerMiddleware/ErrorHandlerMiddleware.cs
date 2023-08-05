using Core.Exceptions;
using System.Net;

namespace API.ErrorHandlerMiddleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ErrorHandling(ex, context);
            }
        }

        private Task ErrorHandling(Exception ex, HttpContext context)
        {
            HttpStatusCode statusCode;
            string stackTrace = ex.StackTrace;
            string message = ex.Message;

            switch(ex)
            {
                case BusinessException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case BusinessNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case BusinessUnauthorizedException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case BusinessForbiddenException:
                    statusCode = HttpStatusCode.Forbidden;
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new { Error = message, stackTrace }));
        }
    }
}
