using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity/recovery")]
    [ApiController]
    public class RecoveryController : ControllerBase
    {
        /// <summary>
        /// Get list of password recovery requests
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
        /// Start password recovery procedure
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult CreateNewRegistration()
        {
            return Ok();
        }

        /// <summary>
        /// Finish password recovery procedure
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
