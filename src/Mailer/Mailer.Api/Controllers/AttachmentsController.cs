using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/mail-management/attachments")]
[ApiController]
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
    public async Task<ActionResult<Application.Attachments.GetAttachments.GetAttachmentsResponse>> GetMultimediaList(int take = 50, int skip = 0)
    {
        return Ok(await _mediator.Send(new Application.Attachments.GetAttachments.GetAttachmentsRequest()
        {
            
        }));
    }

    /// <summary>
    /// Add new multimedia file
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    public IActionResult AddNewMultimediaFile()
    {
        return Ok();
    }

    /// <summary>
    /// Update multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPost("{guid}")]
    public IActionResult UpdateMultimediaFile(Guid guid)
    {
        return Ok();
    }

    /// <summary>
    /// Delete multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("{guid}")]
    public IActionResult DeleteMultimediaFile(Guid guid)
    {
        return Ok();
    }

    /// <summary>
    /// Get thumbnail/icon of multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid}/thumbnail")]
    public IActionResult GetThumbnail(Guid guid)
    {
        return Ok();
    }
}