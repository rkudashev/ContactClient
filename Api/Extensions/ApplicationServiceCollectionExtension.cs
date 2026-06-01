using Api.Storage;

namespace Api.Extensions;
public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        string connectionString = configuration.GetValue<string>("ConnectionStrings:SqliteConnection");
        services.AddSingleton<IStorage>(new SqLiteStorage(connectionString));


        services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(configuration["Client"]);
        }));

        return services;
    }
}