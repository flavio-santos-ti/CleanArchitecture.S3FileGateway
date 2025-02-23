using MediatR;
using S3FileGateway.Application.Dtos;

namespace S3FileGateway.Application.UseCases.Commands;

public class UploadFileCommand : IRequest<string>
{
    public string FileName { get; }
    public Stream FileStream { get; }

    public UploadFileCommand(UploadFileDto uploadFileDto)
    {
        FileName = uploadFileDto.FileContent.FileName;
        FileStream = uploadFileDto.FileContent.OpenReadStream(); // Convertendo IFormFile para Stream
    }
}
