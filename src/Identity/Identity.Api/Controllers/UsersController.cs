using Identity.Persistence;
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
    public class UsersController : ControllerBase
    {
        private readonly IdentityDbContext _dbc;

        public UsersController(IdentityDbContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// Get list of registered users
        /// </summary>
        /// <param name="Take"></param>
        /// <param name="Skip"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetUsersList(int Take = 50, int Skip = 0)
        {
            var users = await _dbc.Users.Include(p=>p.Roles).ThenInclude(p=>p.Claims).Include("UserClaims").ToListAsync();
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
        /// <returns></returns>
        [HttpPut]
        public ActionResult AddNewUser()
        {
            return Ok();
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
