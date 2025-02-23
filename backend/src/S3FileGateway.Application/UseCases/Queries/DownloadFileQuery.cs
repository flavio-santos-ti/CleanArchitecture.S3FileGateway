using MediatR;

namespace S3FileGateway.Application.UseCases.Queries;

public class DownloadFileQuery : IRequest<Stream?>
{
    public string FileName { get; }

    public DownloadFileQuery(string fileName)
    {
        FileName = fileName;
    }
}