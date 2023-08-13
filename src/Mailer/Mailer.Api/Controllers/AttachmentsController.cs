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
    public async Task<ActionResult<Application.Attachments.GetAttachments.Response>> GetMultimediaList(int take = 50, int skip = 0)
    {
        return Ok(await _mediator.Send(new Application.Attachments.GetAttachments.GetAttachmentsRequest
        {
            Take = take,
            Skip = skip
        }));
    }

    /// <summary>
    /// [TO-DO] Add new multimedia file
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddNewMultimediaFile()
    {
        return Ok();
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