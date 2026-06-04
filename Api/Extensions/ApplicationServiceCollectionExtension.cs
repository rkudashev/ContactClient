using Api.DataContext;
using Api.Seed;
using Api.Storage;
using Microsoft.EntityFrameworkCore;

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
        services.AddDbContext<SqliteDbContext>(opt => opt.UseSqlite(connectionString));
        services.AddScoped<IStorage, SqliteEfStorage>();
        services.AddScoped<IInitializer, SqliteEfFakerInitializer>();

        services.AddCors(opt => opt.AddPolicy("CorsPolicy", policy =>
        {
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(configuration["Client"]);
        }));

        return services;
    }
}