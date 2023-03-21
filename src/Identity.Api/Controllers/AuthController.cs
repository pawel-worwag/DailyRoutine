using System.Net.Mime;
using Identity.Shared.Commands.Auth.Tokens;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

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
        [HttpGet("jwks")]
        public ActionResult GetJwkSet()
        {
            return Ok();
        }

        /// <summary>
        /// Create a new tokens with claims
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(TokenResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(500)]
        [HttpPost("tokens")]
        [Consumes(contentType:"application/x-www-form-urlencoded")]
        [Produces(contentType:"application/json")]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> GetTokens([FromForm] GetTokenQuery dto)
        {
            if (string.IsNullOrEmpty(dto.GrantType))
            {
                return StatusCode(400, new ErrorResponse(ErrorResponseValues.InvalidRequest, "No grant_type"));
            }

            switch (dto.GrantType)
            {
                case GrantTypeNames.Password:
                {
                    var ret = await _mediator.Send(new Application.Auth.AccessTokenRequest.AccessTokenRequest()
                    {
                        
                    });
                    return Ok();
                }
                case GrantTypeNames.RefreshToken:
                {
                    return Ok();
                }
            }

            return StatusCode(400, new ErrorResponse(ErrorResponseValues.UnsupportedGrantType,"Bad grant_type"));
        }
    }
}
