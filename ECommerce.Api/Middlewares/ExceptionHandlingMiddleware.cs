using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ECommerce.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"error type is {ex.GetType().ToString()} and error message is {ex.Message}");
                if(ex.InnerException != null)
                    _logger.LogError($"inner error type is {ex.InnerException.GetType().ToString()} and inner error message is {ex.InnerException.Message}");
                httpContext.Response.StatusCode = 500; // internal server error
                await httpContext.Response.WriteAsJsonAsync( new
                {
                    message = ex.Message,
                    type = ex.GetType().ToString()

                });
            }
        }
    }


    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
