using MediatR;

namespace S3FileGateway.Application.UseCases.Commands;

public class DeleteFileCommand : IRequest<bool>
{
    public string FileName { get; }

    public DeleteFileCommand(string fileName)
    {
        FileName = fileName;
    }
}