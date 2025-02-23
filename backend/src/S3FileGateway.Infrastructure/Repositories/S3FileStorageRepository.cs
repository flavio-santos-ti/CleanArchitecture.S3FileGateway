using Amazon.S3;
using Amazon.S3.Model;
using S3FileGateway.Domain.Interfaces;

namespace S3FileGateway.Infrastructure.Repositories;

public class S3FileStorageRepository : IFileStorageRepository
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;
    private readonly string _baseUrl;

    public S3FileStorageRepository(IAmazonS3 s3Client, string bucketName, string baseUrl)
    {
        _s3Client = s3Client ?? throw new ArgumentNullException(nameof(s3Client));
        _bucketName = bucketName ?? throw new ArgumentNullException(nameof(bucketName));
        _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
    }

    public async Task<string> UploadAsync(Stream fileStream, string folderPath, string fileName)
    {
        var key = $"{folderPath.TrimEnd('/')}/{fileName}";

        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = key,
            InputStream = fileStream,
            ContentType = "image/jpeg"
        };

        await _s3Client.PutObjectAsync(request);
        
        return $"{_baseUrl}/{key}";
    }

    public async Task<Stream?> DownloadAsync(string fileName)
    {
        try
        {
            var response = await _s3Client.GetObjectAsync(_bucketName, fileName);
            return response.ResponseStream;
        }
        catch (AmazonS3Exception ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        }
    }

    public async Task<bool> DeleteAsync(string fileName)
    {
        try
        {
            var request = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName
            };

            await _s3Client.DeleteObjectAsync(request);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
