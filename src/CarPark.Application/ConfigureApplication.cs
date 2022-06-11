using System.Reflection;
using CarPark.Application.Car;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarPark.Application;

public static class ConfigureApplication
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
        services.AddScoped<ICarService, CarService>();
        return services;
    }
}