using Identity.Application.Auth.Clients.GetAllRegisteredClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/identity-management/clients/")]
[Produces("application/json")]
public class ClientController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Application.Auth.Clients.GetAllRegisteredClients.Dto.Response>> GetAllRegisteredClients()
    {
        return Ok(await _mediator.Send(new Application.Auth.Clients.GetAllRegisteredClients.GetAllRegisteredClients()
        {

        }));
    }
}