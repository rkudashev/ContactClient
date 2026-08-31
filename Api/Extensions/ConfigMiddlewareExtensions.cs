using Api.Middleware;

namespace Api.Extensions;

public static class ConfigMiddlewareExtensions
{
    public static IApplicationBuilder UseConfigMeddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ConfigMiddleware>();
    }
}