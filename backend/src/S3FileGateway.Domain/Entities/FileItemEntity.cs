namespace S3FileGateway.Domain.Entities;

public class FileItemEntity
{
    public string Id { get; private set; }
    public string FileName { get; private set; }
    public string Url { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public FileItemEntity(string fileName, string url)
    {
        Id = Guid.NewGuid().ToString();
        FileName = fileName;
        Url = url;
        CreatedAt = DateTime.UtcNow;
    }
}