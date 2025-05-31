namespace lab15.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRoleBasedRedirection(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RoleBasedRedirectionMiddleware>();
    }
}
