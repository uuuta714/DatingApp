using System.Net;
using System.Text.Json;

namespace API;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
{
    // next() will look for InvokeAsync(), do not change the name of the method
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Simply move on to the next request delegate
            await next(context);
        }
        catch (Exception ex)
        {
            // Log out to the terminal
            logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = env.IsDevelopment()
                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
                : new ApiException(context.Response.StatusCode, ex.Message, "Internal server error");

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // Provide response as json response so that we can work on the angular client side
            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
}
