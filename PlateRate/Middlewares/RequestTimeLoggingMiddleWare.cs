using System.Diagnostics;

namespace PlateRate.API.Middlewares;

public class RequestTimeLoggingMiddleWare(ILogger<RequestTimeLoggingMiddleWare> logger) : IMiddleware
{ 
    public async Task InvokeAsync(HttpContext context,RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopwatch.Stop();

        if(stopwatch.ElapsedMilliseconds > 4000)
        {
            logger.LogInformation("Request [{Verb}] at {Path} took {Time}ms"
                ,context.Request.Method
                ,context.Request.Path
                ,stopwatch.ElapsedMilliseconds);
        }
    }
}
