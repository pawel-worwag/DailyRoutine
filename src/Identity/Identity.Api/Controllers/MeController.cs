using Identity.Api.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/me")]
    [ApiController]
    [ProducesDefaultContentType]
    public class MeController : ControllerBase
    {
        /// <summary>
        /// [TO-DO] Get my profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMyProfile()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Update my profile
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateMyProfile()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Update my password
        /// </summary>
        /// <returns></returns>
        [HttpPut("password")]
        public ActionResult UpdateMyPassword()
        {
            return Ok();
        }
    }
}
