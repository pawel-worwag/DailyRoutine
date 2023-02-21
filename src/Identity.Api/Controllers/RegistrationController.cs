using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity/registrations")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        /// Get list of user registrations in progress
        /// </summary>
        /// <param name="Take"></param>
        /// <param name="Skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllRequest(int Take=50, int Skip=0)
        {
            return Ok();
        }

        /// <summary>
        /// Start new user registration procedure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CreateNewRegistration()
        {
            return Ok();
        }

        /// <summary>
        /// Finish new user registration procedure
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public ActionResult CompleteRegistration(Guid guid)
        {
            return Ok();
        }
    }
}
