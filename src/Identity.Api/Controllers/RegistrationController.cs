using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/registration-tokens")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        /// <summary>
        /// Get list of user registrations in progress
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllRequest(int take=50, int skip=0)
        {
            return Ok();
        }

        /// <summary>
        /// Start new user registration procedure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CreateNewRegistrationToken()
        {
            return Ok();
        }

        /// <summary>
        /// Finish new user registration procedure
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public ActionResult CompleteRegistrationProcess(Guid guid)
        {
            return Ok();
        }
    }
}
