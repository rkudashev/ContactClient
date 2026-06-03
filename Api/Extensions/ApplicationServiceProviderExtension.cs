using Api.Seed;
using Api.Storage;

namespace Api.Extensions;

public static class ApplicationServiceProviderExtension
{
    public static IServiceProvider AddCustomService(
        this IServiceProvider services,
        IConfiguration configuration)
    {
        using var scope = services.CreateScope();
        var storage = scope.ServiceProvider.GetService<IStorage>();
        var dbStorage = storage as SqLiteStorage;

        if(dbStorage != null)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            new FakerInitializer(connectionString).Initialize();
        }

        return services;
    }
}