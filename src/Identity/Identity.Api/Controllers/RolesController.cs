using System.Net.Mime;
using Identity.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/roles/")]
    [ApiController]
    [ProducesDefaultContentType]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// [TO-DO] Get list of allowed roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Application.Roles.GetRoles.Response>> GetRolesList()
        {
            return Ok(await _mediator.Send(new Application.Roles.GetRoles.GetRolesRequest()));
        }
    }
}
