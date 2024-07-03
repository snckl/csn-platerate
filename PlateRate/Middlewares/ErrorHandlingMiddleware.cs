
using Microsoft.AspNetCore.Http;
using PlateRate.Domain.Exceptions;

namespace PlateRate.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFoundEx)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(notFoundEx.Message);

            logger.LogWarning("StatusCode: " + context.Response.StatusCode + " - " + notFoundEx.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("StatusCode: " + context.Response.StatusCode + " - " + "Something went wrong.");
        }
        
    }
}
