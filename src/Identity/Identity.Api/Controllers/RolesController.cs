using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management/roles/")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        /// <summary>
        /// [TO-DO] Get list of allowed roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetRolesList()
        {
            return Ok();
        }
    }
}
