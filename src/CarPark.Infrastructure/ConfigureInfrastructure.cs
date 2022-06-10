using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarPark.Infrastructure;

public static class ConfigureInfrastructure
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string mySqlConnectionStr = configuration.GetConnectionString("CarParkDatabase");
        services.AddDbContext<CarParkDbContext>(options => options
#if DEBUG
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
#endif
            .UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
        return services;
    }
}