using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/mail-management")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
    }
}
