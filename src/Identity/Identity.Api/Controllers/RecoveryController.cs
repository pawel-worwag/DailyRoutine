using Identity.Api.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/recovery-password-tokens")]
    [ApiController]
    [ProducesDefaultContentType]
    public class RecoveryController : ControllerBase
    {
        /// <summary>
        /// [TO-DO] Get list of password recovery requests (only metadata)
        /// </summary>
        /// <param name="Take"></param>
        /// <param name="Skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllRequest(int Take = 50, int Skip = 0)
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Create new recovery token / start password recovery procedure
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StartNewRecoveryProcess()
        {
            return Ok();
        }

        /// <summary>
        /// [TO-DO] Finish password recovery procedure
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
