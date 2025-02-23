using MediatR;
using S3FileGateway.Application.Dtos;
using S3FileGateway.Application.Services;
using S3FileGateway.Application.UseCases.Commands;

namespace S3FileGateway.Application.Handlers;

public class UploadFileHandler : IRequestHandler<UploadFileCommand, string>
{
    private readonly IFileUploadService _fileUploadService;

    public UploadFileHandler(IFileUploadService fileUploadService)
    {
        _fileUploadService = fileUploadService ?? throw new ArgumentNullException(nameof(fileUploadService));
    }

    public async Task<string> Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        
        return await _fileUploadService.UploadFileAsync(request.FileStream, request.FileName);
    }
}