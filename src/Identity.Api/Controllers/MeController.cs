using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/me")]
    [ApiController]
    public class MeController : ControllerBase
    {
        /// <summary>
        /// Get my profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetMyProfile()
        {
            return Ok();
        }

        /// <summary>
        /// Update my profile
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateMyProfile()
        {
            return Ok();
        }

        /// <summary>
        /// Update my password
        /// </summary>
        /// <returns></returns>
        [HttpPost("password")]
        public ActionResult UpdateMyPassword()
        {
            return Ok();
        }
    }
}
