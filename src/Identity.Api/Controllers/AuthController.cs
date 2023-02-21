using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Server discovery endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet("openid-configuration")]
        public ActionResult GetOpenIdConfiguration()
        {
            return Ok();
        }

        /// <summary>
        /// Get JSON Web Keys set
        /// </summary>
        /// <returns></returns>
        [HttpGet("jwks.json")]
        public ActionResult GetJwkSet()
        {
            return Ok();
        }

        /// <summary>
        /// Get tokens with a claims
        /// </summary>
        /// <returns></returns>
        [HttpPost("token")]
        public ActionResult GetTokens()
        {
            return Ok();
        }
    }
}
