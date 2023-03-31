using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of registered users
        /// </summary>
        /// <param name="Take"></param>
        /// <param name="Skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUsersList(int Take = 50, int Skip = 0)
        {
            return Ok();
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public ActionResult GetUserDetails(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Guid> AddNewUser(Identity.Shared.Commands.Users.AddNewUser.AddNewUserQuery dto)
        {
            var guid = await _mediator.Send(new Application.Users.AddNewUserRequest.AddNewUserRequest(){dto = dto});
            return guid;
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public ActionResult UpdateUser(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// Send Welcome-Email to user
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
