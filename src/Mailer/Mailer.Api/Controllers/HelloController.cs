using System.Net;
using System.Text;
using Mailer.Application.Common.Interfaces;
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
        private IAttachmentsStore _store;

        public HelloController(IAttachmentsStore store)
        {
            _store = store;
        }

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
