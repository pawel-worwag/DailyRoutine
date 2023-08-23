using System.Net;
using Mailer.Api.Common;
using Mailer.Api.Common.Exceptions;
using Mailer.Api.Models.Attachments;
using Mailer.Shared.Abstractions.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mailer.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/mail-management/attachments")]
[ApiController]
[ProducesDefaultContentType]
public class AttachmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public AttachmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// List of uploaded files
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Application.Attachments.GetAttachments.Response>> GetMultimediaList(int take = 50,
        int skip = 0)
    {
        return Ok(await _mediator.Send(new Application.Attachments.GetAttachments.GetAttachmentsRequest
        {
            Take = take,
            Skip = skip
        }));
    }

    /// <summary>
    /// Add new attachment
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddNewMultimediaFile([FromForm] Models.Attachments.AddNewAttachmentDto dto)
    {
        if (!ModelState.IsValid)
        {
            throw new CustomValidationException(ModelState);
        }
        if (dto.File.Length <= 0)
        {
            throw new Exception("File size is 0.");
        }

        var filePath = Path.GetTempFileName();

        await using (var stream = System.IO.File.Create(filePath))
        {
            await dto.File.CopyToAsync(stream);
        }

        var id = await _mediator.Send(new Application.Attachments.AddAttachment.AddAttachmentRequest
        {
            Name = dto.Name,
            Description = dto.Description,
            MediaType = dto.MediaType,
            Inline = dto.Inline,
            FileTempPath = filePath
        });

        System.IO.File.Delete(filePath);
        var url = this.Url.Action("GetDetails", new { guid = id });
        return Created(new Uri(url!, UriKind.Relative), null);
    }


    /// <summary>
    /// Get attachment details
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}")]
    public async Task<ActionResult<Application.Attachments.GetDetails.Response>> GetDetails(Guid guid)
    {
        return Ok(await _mediator.Send(new Mailer.Application.Attachments.GetDetails.GetDetailsRequest
        {
            Guid = guid
        }));
    }

    /// <summary>
    /// Update attachment metadata
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{guid:guid}")]
    public async Task<IActionResult> UpdateMultimediaFile(Guid guid, UpdateAttachmentMetadataDto dto)
    {
        await _mediator.Send(new Application.Attachments.UpdateAttachmentMetadata.UpdateAttachmentMetadataRequest
        {
            Guid = guid,
            Name = dto.Name,
            MediaType = dto.MediaType,
            Description = dto.Description,
            Inline = dto.Inline
        });
        return Ok();
    }

    /// <summary>
    /// Delete attachment
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("{guid:guid}")]
    public async Task<IActionResult> DeleteMultimediaFile(Guid guid)
    {
        await _mediator.Send(new Application.Attachments.DeleteAttachment.DeleteAttachmentRequest
        {
            Guid = guid
        });
        return Ok(guid);
    }

    /// <summary>
    /// [PARTIAL] Get thumbnail/icon of multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}/thumbnail")]
    public async Task<IActionResult> GetThumbnail(Guid guid)
    {
        var meta = await _mediator.Send(new Application.Attachments.DownloadThumbnail.DownloadThumbnailRequest
        {
            Guid = guid
        });
        return File(await System.IO.File.ReadAllBytesAsync(meta.FileTempPath),"image/png",meta.Name);
    }

    /// <summary>
    /// Get multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}/file")]
    public async Task<IActionResult> GetFile(Guid guid)
    {
        var meta = await _mediator.Send(new Application.Attachments.DownloadAttachment.DownloadAttachment
        {
            Guid = guid
        });
        return File(await System.IO.File.ReadAllBytesAsync(meta.FileTempPath),meta.MimeType,meta.Name);
    }

    /// <summary>
    /// Update attachment file
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPut("{guid:guid}/file")]
    public async Task<IActionResult> UpdateFile(Guid guid, [FromForm] IFormFile file)
    {
        if (file.Length <= 0)
        {
            throw new EmptyFileException("File size is 0.");
        }

        var filePath = Path.GetTempFileName();

        await using (var stream = System.IO.File.Create(filePath))
        {
            await file.CopyToAsync(stream);
        }

        await _mediator.Send(new Application.Attachments.UpdateAttachmentFile.UpdateAttachmentFileRequest
        {
            Guid = guid,
            FileTempPath = filePath
        });
        
        System.IO.File.Delete(filePath);
        return Ok();
    }
}