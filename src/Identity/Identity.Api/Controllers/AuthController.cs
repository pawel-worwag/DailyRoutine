using Identity.Api.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/")]
    [ApiController]
    [ProducesDefaultContentType]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// [TO-DO] Server discovery endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet("openid-configuration")]
        public ActionResult GetOpenIdConfiguration()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Get JSON Web Keys set
        /// </summary>
        /// <returns></returns>
        [HttpGet("jwks")]
        public ActionResult GetJwkSet()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Create a new tokens with claims
        /// </summary>
        /// <returns></returns>
        [HttpPost("tokens")]
        public ActionResult GetTokens()
        {
            return Ok();
        }
    }
}
