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
            await client.SendAsync(new MailData()
            {
                To=new List<string>(){"pawel.worwag@gmail.com"},
                Subject = "[DailyRoutine] Test",
                Body = "<html><body><h1>Test</h1><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat nisl auctor finibus tempor. Donec ullamcorper mollis nunc, eu fermentum eros. Maecenas luctus ac ex at dignissim. Nullam augue est, gravida a sagittis sed, egestas in lectus. Vivamus et turpis ut turpis hendrerit convallis. Fusce eget finibus diam. Aenean tellus dui, laoreet ac aliquet nec, placerat in nisi. Nulla mauris nunc, efficitur nec egestas vitae, maximus et urna.</p></body></html>"
            },new CancellationToken());
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
