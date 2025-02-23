using Microsoft.AspNetCore.Http;

namespace S3FileGateway.Application.Dtos;

public class UploadFileDto
{
    public IFormFile FileContent { get; set; } = null!;
}