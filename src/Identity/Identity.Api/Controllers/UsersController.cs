using Identity.Api.Common;
using Identity.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/users")]
    [ApiController]
    [ProducesDefaultContentType]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// [PARTIAL] Get list of registered users
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Application.Users.GetUsers.Response>> GetUsersList(int take = 50, int skip = 0)
        {
            return Ok(await _mediator.Send(new Application.Users.GetUsers.GetUsersRequest
            {
                Take = take,
                Skip = skip
            }));
        }

        /// <summary>
        /// [TO-DO] Get user details
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public ActionResult GetUserDetails(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Add new user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddNewUser()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Update user data
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPut("{guid}")]
        public ActionResult UpdateUser(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Send Welcome-Email to user
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}/send-welcome-email")]
        public ActionResult SendWelcomeEmeil(Guid guid)
        {
            return Ok();
        }
    }
}
