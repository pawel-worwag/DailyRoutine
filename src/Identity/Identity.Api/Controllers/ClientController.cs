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
    /// Add new api client
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> AddClient(Models.Clients.AddClientDto dto)
    {
        var guid = await _mediator.Send(new Application.Clients.AddClient.AddClientRequest
        {
            Name = dto.Name,
            Endpoints = dto.Endpoints
        });
        
        var url = this.Url.Action("GetClientDetails", new { guid = guid });
        return Created(new Uri(url!, UriKind.Relative), null);
    }
    
    /// <summary>
    /// Get client details
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpGet("{guid:guid}")]
    public async Task<ActionResult<Application.Clients.GetClientDetails.Response>> GetClientDetails(Guid guid)
    {
        return Ok(await _mediator.Send(new Application.Clients.GetClientDetails.GetClientDetailsRequest
        {
            Guid = guid
        }));
    }  
    
    /// <summary>
    /// Update api client
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{guid:guid}")]
    public async Task<ActionResult> UpdateClient(Guid guid, Models.Clients.UpdateClientDto dto)
    {
        await _mediator.Send(new Application.Clients.UpdateClient.UpdateClientRequest
        {
            Guid = guid,
            Name = dto.Name,
            Endpoints = dto.Endpoints
        });
        return Ok();
    }    
    
    /// <summary>
    /// Remove api client
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    [HttpDelete("{guid:guid}")]
    public async Task<ActionResult> RemoveClient(Guid guid)
    {
        await _mediator.Send(new Application.Clients.DeleteClient.DeleteClientRequest
        {
            Guid = guid
        });
        return Ok();
    }
    
}