using System.Net;
using Mailer.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    /// Add new multimedia file
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddNewMultimediaFile([FromForm] Models.Attachments.AddNewAttachmentDto dto)
    {
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
        return Created(new Uri(url, UriKind.Relative), null);
    }


    /// <summary>
    /// Get multimedia  details
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
    /// [TO-DO] Update multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPut("{guid:guid}")]
    public IActionResult UpdateMultimediaFile(Guid guid)
    {
        return Ok(guid);
    }

    /// <summary>
    /// [TO-DO] Delete multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("{guid:guid}")]
    public IActionResult DeleteMultimediaFile(Guid guid)
    {
        return Ok(guid);
    }

    /// <summary>
    /// [TO-DO] Get thumbnail/icon of multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}/thumbnail")]
    public IActionResult GetThumbnail(Guid guid)
    {
        return Ok(guid);
    }

    /// <summary>
    /// [TO-DO] Get multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}/file")]
    public IActionResult GetFile(Guid guid)
    {
        return Ok(guid);
    }
}