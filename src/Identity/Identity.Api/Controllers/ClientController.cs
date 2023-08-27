using Identity.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("api/identity-management/clients/")]
[ProducesDefaultContentType]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get registered clients
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Application.Clients.GetClients.Response>> GetAllRegisteredClients()
    {
        return Ok(await _mediator.Send(new Application.Clients.GetClients.GetClientsRequest()));
    }

    /// <summary>
    /// [TO-DO] Add new api client
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult AddClient()
    {
        return Ok();
    }
    
    /// <summary>
    /// [TO-DO] Update api client
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpPost("{guid:guid}")]
    public ActionResult UpdateClient(Guid guid)
    {
        return Ok();
    }    
    
    /// <summary>
    /// [TO-DO] Remove api client
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("{guid:guid}")]
    public ActionResult RemoveClient(Guid guid)
    {
        return Ok();
    }
    
}