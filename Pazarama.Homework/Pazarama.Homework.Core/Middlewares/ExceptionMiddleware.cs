using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Pazarama.Homework.Core.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext,ILogger<ExceptionMiddleware> _logger)
    {
        try
        {
           await _next(httpContext);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
        }
    }
}