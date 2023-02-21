﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
    }
}
