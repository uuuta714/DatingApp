using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers;

public class LogUserActivity : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Anything here happens before the action in the API controller is executed 
        var resultContext = await next();
        // Anything here happens after the action in the API controller is executed

        if (context.HttpContext.User.Identity?.IsAuthenticated != true) return;

        var userId = resultContext.HttpContext.User.GetUserId();
        var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
        var user = await repo.GetUserByIdAsync(userId);

        if (user == null) return;

        user.LastActive = DateTime.UtcNow;
        await repo.SaveAllAsync();
    }
}
