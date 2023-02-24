using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/identity-management/")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
    }
}
