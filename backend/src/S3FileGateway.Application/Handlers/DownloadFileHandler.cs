using MediatR;
using S3FileGateway.Application.UseCases.Queries;
using S3FileGateway.Domain.Interfaces;

namespace S3FileGateway.Application.Handlers;

public class DownloadFileHandler : IRequestHandler<DownloadFileQuery, Stream?>
{
    private readonly IFileStorageRepository _repository;

    public DownloadFileHandler(IFileStorageRepository repository)
    {
        _repository = repository;
    }

    public async Task<Stream?> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
    {
        return await _repository.DownloadAsync(request.FileName);
    }
}