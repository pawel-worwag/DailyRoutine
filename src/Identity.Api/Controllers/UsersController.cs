using Identity.Shared.Commands.Users.GetUsersList;
using MediatR;
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
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<GetUsersListResponse> GetUsersList(int take = 50, int skip = 0)
        {
            return await _mediator.Send(new Application.Users.GetUsersListRequest.GetUsersListRequest()
            {
                Take = take,
                Skip = skip
            });
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
        public async Task<Guid> AddNewUser(Shared.Commands.Users.AddNewUser.AddNewUserQuery dto)
        {
            var guid = await _mediator.Send(new Application.Users.AddNewUserRequest.AddNewUserRequest(){Dto = dto});
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
