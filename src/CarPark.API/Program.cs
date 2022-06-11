using CarPark.Application;
using CarPark.Infrastructure;

namespace CarPark.API;

public static class Program
{
    public static void Main(string[] args)
        => WebApplication.CreateBuilder(args)
            .RegisterService()
            .Build()
            .RegisterRequestPipeline()
            .Run();

    private static WebApplicationBuilder RegisterService(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddApplication(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }

    private static WebApplication RegisterRequestPipeline(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        return app;
    }
}