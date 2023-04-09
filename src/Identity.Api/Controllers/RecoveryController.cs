using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/recovery-password-tokens")]
    [ApiController]
    public class RecoveryController : ControllerBase
    {
        /// <summary>
        /// Get list of password recovery requests (only metadata)
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllRequest(int take = 50, int skip = 0)
        {
            return Ok();
        }

        /// <summary>
        /// Create new rescovery token / start password recovery procedure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult StartNewRecoveryProcess()
        {
            return Ok();
        }

        /// <summary>
        /// Finish password recovery procedure
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}/complete")]
        public ActionResult CompleteRecoveryProcess(Guid guid)
        {
            return Ok();
        }
    }
}
