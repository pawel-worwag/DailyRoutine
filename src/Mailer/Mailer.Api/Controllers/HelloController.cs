using System.Net;
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
        [HttpGet("/test")]
        public async Task<ActionResult> Test(IMailClient client)
        {
            await client.SendDemoAsync(new CancellationToken());
            return Ok();
        }

        [HttpPut("/test/{id:guid}")]
        public async Task<ActionResult> WriteFileTest(Guid id)
        {
            var cts = new CancellationTokenSource();
            
            var body = Convert.FromBase64String("QWxhIG1hIGtvdGEsIGEga290IG1hIEFsZS4=");
            await _store.WriteFileAsync(id.ToString(), body,cts.Token);
            return Ok();
        }

        [HttpGet("/test/{id:guid}")]
        public async Task<ActionResult> ReadFileTest(Guid id)
        {
            var cts = new CancellationTokenSource();

            var bytes = await _store.ReadFileAsync(id.ToString(), cts.Token);
            return File(bytes, "text/plain");
        }
    }
}
