using Microsoft.AspNetCore.Http;
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
        /// [TO-DO] Get list of user registrations in progress
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
        /// [TO-DO] Start new user registration procedure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CreateNewRegistrationToken()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Finish new user registration procedure
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
