using System.Net;
using Identity.Application.Auth.AccessTokenRequest;
using Identity.Shared.Commands.Auth.Tokens;
using Identity.Shared.Common;
using Identity.Shared.Enums;
using Identity.Shared.Exceptions;
using MediatR;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
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
        [ProducesResponseType(typeof(AuthErrorResponse), 400)]
        [ProducesResponseType(typeof(AuthErrorResponse), 401)]
        [ProducesResponseType(500)]
        [HttpPost("tokens")]
        [Consumes(contentType:"application/x-www-form-urlencoded")]
        [Produces(contentType:"application/json")]
        [ResponseCache(NoStore = true)]
        public async Task<IActionResult> GetTokens([FromForm] GetTokenQuery dto)
        {
            if (string.IsNullOrEmpty(dto.GrantType))
            {
                throw new AuthException(HttpStatusCode.BadRequest, 
                    AuthErrorResponseNames.InvalidRequest,"No grant_type");
            }

            switch (dto.GrantType)
            {
                case GrantTypeNames.Password:
                {
                    var ret = await _mediator.Send(new AccessTokenRequest()
                    {
                        Username = dto.Username??"",
                        Password = dto.Password??"",
                        Scope = dto.Scope
                    });
                    return Ok(ret);
                }
                case GrantTypeNames.RefreshToken:
                {
                    throw new AuthException(HttpStatusCode.BadRequest, 
                        AuthErrorResponseNames.UnsupportedGrantType,$"Bad grant_type '{dto.GrantType}'.");
                }
                default:
                {
                    throw new AuthException(HttpStatusCode.BadRequest, 
                        AuthErrorResponseNames.UnsupportedGrantType,$"Bad grant_type '{dto.GrantType}'.");
                }
            }
        }
    }
}
