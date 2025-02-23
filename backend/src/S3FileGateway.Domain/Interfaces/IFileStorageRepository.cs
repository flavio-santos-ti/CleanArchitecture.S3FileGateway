namespace S3FileGateway.Domain.Interfaces;

public interface IFileStorageRepository
{
    Task<string> UploadAsync(Stream fileStream, string folderPath, string fileName);
    Task<Stream?> DownloadAsync(string fileName);
    Task<bool> DeleteAsync(string fileName);
}