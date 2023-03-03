using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    [Route("api/mail-management")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        /// <summary>
        /// List of allowed languages
        /// </summary>
        /// <returns></returns>
        [HttpGet("allowed-languages")]
        public ActionResult GetAllowedLanguages()
        {
            return Ok();
        }

        /// <summary>
        /// List of defined email types
        /// </summary>
        /// <returns></returns>
        [HttpGet("allowed-email-types")]
        public ActionResult GetAllowedEmailTypes()
        {
            return Ok();
        }

        /// <summary>
        /// List of templates
        /// </summary>
        /// <returns></returns>
        [HttpGet("templates")]
        public ActionResult GetTemplates()
        {
            return Ok();
        }

        /// <summary>
        /// Add new template
        /// </summary>
        /// <returns></returns>
        [HttpPut("templates")]
        public ActionResult AddTemplate()
        {
            return Ok();
        }

        /// <summary>
        /// Get template tetails
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("templates/{guid}")]
        public ActionResult GetTemplate(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// Update template
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("templates/{guid}")]
        public ActionResult UpdateTemplate(Guid guid)
        {
            return Ok();
        }

        /// <summary>
        /// Send a test email
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("templates/{guid}/send-test")]
        public ActionResult SendTest(Guid guid)
        {
            return Ok();
        }
    }
}
