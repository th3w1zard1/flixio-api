namespace Flixio.Api.Middleware;

public class HardcodedUserMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Items["AuthKey"] = Constants.DefaultAuthKey;
        context.Items["User"] = Constants.DefaultUser;
        
        await next(context);
    }
}