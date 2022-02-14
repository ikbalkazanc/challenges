using Microsoft.AspNetCore.Builder;
using Pazarama.Homework.Core.Middlewares;

namespace Pazarama.Homework.Core.Extension;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseExceptionLogHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}