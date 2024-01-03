using Identity.Api.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management-old/")]
    [ApiController]
    [ProducesDefaultContentType]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
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
        public async Task<ActionResult<Models.Auth.OpenIdConfiguration>> GetOpenIdConfiguration()
        {
            var config = await _mediator.Send(new Application.Auth.GetDiscovery.GetDiscoveryRequest());
            return Ok(config);
        }

        /// <summary>
        /// Get JSON Web Keys set
        /// </summary>
        /// <returns></returns>
        [HttpGet("jwks")]
        public async Task<ActionResult<Models.Auth.Jwks>> GetJwkSet()
        {
            var jwks = await _mediator.Send(new Application.Auth.GetJwks.GetJwksRequest());
            return Ok(new Models.Auth.Jwks
            {
                Keys = jwks.Keys.Select(p=>new Models.Auth.Key
                {
                    Alg = p.Alg,
                    E = p.E,
                    Kid = p.Kid,
                    Kty = p.Kty,
                    N = p.N,
                    Use = p.Use,
                    X5c = p.X5c,
                    X5t = p.X5t
                }).ToList()
            });
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
