using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S3FileGateway.Application.Handlers;
using S3FileGateway.Infrastructure.Configurations;
using S3FileGateway.Application.Configurations;

namespace S3FileGateway.Config.Configurations;

public static class ConfigConfiguration
{
    public static IServiceCollection AddConfigServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UploadFileHandler).Assembly));


        // Adiciona os serviços da Infrastructure Layer e passa a configuração
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        return services;
    }
}