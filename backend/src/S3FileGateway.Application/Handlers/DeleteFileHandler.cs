using MediatR;
using S3FileGateway.Application.UseCases.Commands;
using S3FileGateway.Domain.Interfaces;

namespace S3FileGateway.Application.Handlers;

public class DeleteFileHandler : IRequestHandler<DeleteFileCommand, bool>
{
    private readonly IFileStorageRepository _repository;

    public DeleteFileHandler(IFileStorageRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.FileName);
    }
}