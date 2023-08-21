using Mailer.Api.Common;
using Mailer.Application.Templates.GetAllowedEmailTypes;
using Mailer.Application.Templates.GetAllowedLanguages;
using Mailer.Application.Templates.GetTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Response = Mailer.Application.Templates.GetAllowedLanguages.Response;

namespace Mailer.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/mail-management")]
[ApiController]
[ProducesDefaultContentType]
public class TemplatesController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public TemplatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// List of allowed languages
    /// </summary>
    /// <returns></returns>
    [HttpGet("allowed-languages")]
    public async Task<ActionResult<Response>> GetAllowedLanguages()
    {
        return Ok(await _mediator.Send(new GetAllowedLanguagesRequest()));
    }

    /// <summary>
    /// List of defined email types
    /// </summary>
    /// <returns></returns>
    [HttpGet("allowed-email-types")]
    public async Task<ActionResult<Application.Templates.GetAllowedEmailTypes.Response>> GetAllowedEmailTypes()
    {
        return Ok(await _mediator.Send(new GetAllowedEmailTypesRequest()));
    }

    /// <summary>
    /// List of templates
    /// </summary>
    /// <returns></returns>
    [HttpGet("templates")]
    public async Task<ActionResult<Mailer.Application.Templates.GetTemplates.Response>> GetTemplates()
    {
        return Ok(await _mediator.Send(new GetTemplatesRequest()));
    }

    /// <summary>
    /// Add new template
    /// </summary>
    /// <returns></returns>
    [HttpPost("templates")]
    public async Task<ActionResult> AddTemplate(Models.Templates.AddNewTemplateDto dto)
    {
        var id = await _mediator.Send(new Application.Templates.AddTemplate.AddTemplateRequest
        {
            Type = dto.Type,
            Language = dto.Language,
            Subject = dto.Subject,
            BodyEncoded = dto.BodyEncoded,
            Attachments = dto.Attachments
        });
        var url = this.Url.Action("GetTemplate", new { guid = id });
        return Created(new Uri(url!, UriKind.Relative), null);
    }

    /// <summary>
    /// Get template details
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("templates/{guid:guid}")]
    public async Task<ActionResult<Application.Templates.GetDetails.Response>> GetTemplate(Guid guid)
    {
        return Ok(await _mediator.Send(new Application.Templates.GetDetails.GetDetailsRequest
        {
            Guid = guid
        }));
    }

    /// <summary>
    /// [TO-DO] Update template
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPut("templates/{guid:guid}")]
    public ActionResult UpdateTemplate(Guid guid)
    {
        return Ok(guid);
    }

    /// <summary>
    /// [TO-DO] Send a test email
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPost("templates/{guid:guid}/send-test")]
    public ActionResult SendTest(Guid guid)
    {
        return Ok(guid);
    }

    /*
    /// <summary>
    /// Get list of related multimedia files
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("templates/{guid:guid}/attachments")]
    public async Task<ActionResult<Mailer.Application.Templates.GetTemplateAttachments.Response>> GetRelatedMultimediaFiles(Guid guid)
    {
        return Ok(await _mediator.Send(new Mailer.Application.Templates.GetTemplateAttachments.GetTemplateAttachmentsRequest
        {
            TemplateGuid = guid
        }));
    }
    */
    /*
    /// <summary>
    /// [TO-DO] Add related multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPost("templates/{guid:guid}/attachments")]
    public IActionResult AddRelatedMultimediaFile(Guid guid)
    {
        return Ok(guid);
    }
    */
    /*
    /// <summary>
    /// [TO-DO] Delete related multimedia file
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("templates/{guid:guid}/attachments")]
    public IActionResult DeleteRelatedMultimediaFile(Guid guid)
    {
        return Ok(guid);
    }
    */
}