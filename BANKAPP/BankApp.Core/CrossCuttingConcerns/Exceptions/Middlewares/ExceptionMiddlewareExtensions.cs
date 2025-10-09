using Microsoft.AspNetCore.Builder;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
} 