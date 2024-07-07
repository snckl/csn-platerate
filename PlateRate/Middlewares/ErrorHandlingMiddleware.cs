
using Microsoft.AspNetCore.Http;
using PlateRate.Domain.Exceptions;

namespace PlateRate.API.Middlewares;

public class ErrorHandlingMiddleWare(ILogger<ErrorHandlingMiddleWare> logger) : IMiddleware
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
        catch (ForbidException forbidEx)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access forbidden");

        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);

            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("StatusCode: " + context.Response.StatusCode + " - " + "Something went wrong.");
        }
        
    }
}
