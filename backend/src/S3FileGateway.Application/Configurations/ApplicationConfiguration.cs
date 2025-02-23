using Microsoft.Extensions.DependencyInjection;
using S3FileGateway.Application.Services;
using System.Reflection;

namespace S3FileGateway.Application.Configurations;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registra a service FileUploadService na camada Application
        services.AddScoped<IFileUploadService, FileUploadService>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}
