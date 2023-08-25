﻿using Identity.Api.Common;
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
    [ProducesDefaultContentType]
    public class UsersController : ControllerBase
    {
        private readonly IdentityDbContext _dbc;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbc"></param>
        public UsersController(IdentityDbContext dbc)
        {
            _dbc = dbc;
        }

        /// <summary>
        /// [TO-DO] Get list of registered users
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
