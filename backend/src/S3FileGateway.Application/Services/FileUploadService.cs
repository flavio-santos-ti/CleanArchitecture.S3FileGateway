using S3FileGateway.Application.Dtos;
using S3FileGateway.Domain.Interfaces;

namespace S3FileGateway.Application.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IFileStorageRepository _fileStorageRepository;

    public FileUploadService(IFileStorageRepository fileStorageRepository)
    {
        _fileStorageRepository = fileStorageRepository ?? throw new ArgumentNullException(nameof(fileStorageRepository));
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        // Validação do arquivo
        if (fileStream == null || fileStream.Length == 0)
            throw new ArgumentException("O arquivo enviado não pode ser nulo ou vazio.");

        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("O nome do arquivo não pode ser vazio.");

        // Define a pasta com base na extensão do arquivo
        string folderPath = GetFolderNameFromExtension(fileName);

        // Chama o repositório para armazenar o arquivo no S3
        return await _fileStorageRepository.UploadAsync(fileStream, folderPath, fileName);
    }

    private string GetFolderNameFromExtension(string fileName)
    {
        var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();

        return fileExtension switch
        {
            ".jpg" => "jpg",
            ".jpeg" => "jpg",
            ".pdf" => "pdf",
            _ => "outros" // Caso a extensão seja diferente, salva na pasta "outros"
        };
    }
}
