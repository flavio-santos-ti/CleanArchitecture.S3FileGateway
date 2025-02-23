using Amazon.Runtime;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S3FileGateway.Domain.Interfaces;
using S3FileGateway.Infrastructure.Repositories;

namespace S3FileGateway.Infrastructure.Configurations;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Retrieve the AWS credentials that are in the appsettings.json
        var accessKey = configuration["AWS:AccessKey"];
        var secretKey = configuration["AWS:SecretKey"];

        if (string.IsNullOrEmpty(accessKey) || string.IsNullOrEmpty(secretKey))
            throw new ArgumentNullException("As credenciais da AWS não foram configuradas corretamente.");

        var credentials = new BasicAWSCredentials(accessKey, secretKey);

        // Retrieve the AWS region from the appsettings.json
        var region = configuration["AWS:Region"];
        if (string.IsNullOrEmpty(region))
            throw new ArgumentNullException(nameof(region), "Region não pode estar vazia.");

        // Registers the AWS credentials
        services.AddSingleton<AWSCredentials>(credentials);

        // Registers the AmazonS3 client as a singleton service in the DI container.
        services.AddSingleton<IAmazonS3>(provider =>
        {
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(region)
            };
            return new AmazonS3Client(credentials, config);
        });

        var bucketName = configuration["AWS:BucketName"];
        var baseUrl = configuration["AWS:BaseUrl"];

        if (string.IsNullOrEmpty(bucketName))
            throw new ArgumentNullException(nameof(bucketName), "BucketName não pode estar vazio.");

        if (string.IsNullOrEmpty(baseUrl))
            throw new ArgumentNullException(nameof(baseUrl), "BaseUrl não pode estar vazia.");

        services.AddScoped<IFileStorageRepository>(provider =>
        {
            var s3Client = provider.GetRequiredService<IAmazonS3>();
            var bucketName = configuration["AWS:BucketName"];

            if (string.IsNullOrEmpty(bucketName))
                throw new ArgumentNullException(nameof(bucketName), "BucketName não pode estar vazio.");

            return new S3FileStorageRepository(s3Client, bucketName, baseUrl);
        });

        return services;
    }
}