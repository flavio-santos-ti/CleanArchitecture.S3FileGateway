using MediatR;
using Microsoft.AspNetCore.Mvc;
using S3FileGateway.Application.Dtos;
using S3FileGateway.Application.UseCases.Commands;

namespace S3FileGateway.Api.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{
    private readonly IMediator _mediator;

    public FileController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] UploadFileDto request)
    {
        var originalFileName = request.FileContent.FileName;
        var command = new UploadFileCommand(request);
        var fileUrl = await _mediator.Send(command);
        return Created(fileUrl, new { Url = fileUrl });
    }

}
