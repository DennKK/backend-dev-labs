namespace lab15.Middleware;

public class RoleBasedRedirectionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var path = context.Request.Path.Value?.ToLower();

            if (path?.StartsWith("/admin") == true)
            {
                if (!context.User.IsInRole("Admin"))
                {
                    context.Response.Redirect("/access-denied");
                    return;
                }
            }

            if (path?.StartsWith("/manager") == true)
            {
                if (!context.User.IsInRole("Manager") && !context.User.IsInRole("Admin"))
                {
                    context.Response.Redirect("/access-denied");
                    return;
                }
            }
        }
        else
        {
            var path = context.Request.Path.Value?.ToLower();
            if (path?.StartsWith("/admin") == true || path?.StartsWith("/manager") == true)
            {
                context.Response.Redirect("/login");
                return;
            }
        }

        await next(context);
    }
}
