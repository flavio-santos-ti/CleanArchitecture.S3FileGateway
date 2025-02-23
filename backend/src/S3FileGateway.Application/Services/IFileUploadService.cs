namespace S3FileGateway.Application.Services;

public interface IFileUploadService
{
    Task<string> UploadFileAsync(Stream fileStream, string fileName);
}