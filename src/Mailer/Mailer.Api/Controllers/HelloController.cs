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
        [HttpGet("/test")]
        public async Task<ActionResult> Test(IMailClient client)
        {
            var file = Convert.FromBase64String(
                "iVBORw0KGgoAAAANSUhEUgAAAFAAAABQCAMAAAC5zwKfAAAAA3NCSVQICAjb4U/gAAAAGFBMVEVDdOCgw/+jxv83bd6KrvZdh+dzmu6YvPy6ZgMjAAABf0lEQVRYhe3WS67DIAwFUGJ++99xgSBVAfsaGvSap8Kkox455uNrjsXLbHCDG9zgc0Cqaw1I5II31hof3ICpgUQhY2Wl36CSCkjOVK2axikiBilcuEIGLEKQ8VQRgayniQAkx3pJRH1EIM/l9REoFohLBKBcICpRBqNYYCoxzoPCFtclb7QMevTJ/gkg8sCuSCCtBtd/8hGAB66zXKF8UeBV+buDDZsotxC9NuhxkP+Fni+xRFAgfLGlLoIOKiOA/2j4YCtTjxOxp43RXlQ8ddBHfx30Pt4a9CXZeHtmkfTjtdwwEJZy6EppKa3gjoH89YU4N7n+PXi2LrqyYhzoJLx6FM80/F45F0eIyi92itbG2v6mlOMoHyAeTLW9ozX3PuQjzpssmDigVVNI2xyIY41yr3uQohny8oczRfYgmnYd2c/nDpzxOLEFlUjTi+18aUCYF1iwnYBthTAijZTYgpMF9kP/CtLclujg8gonD803Knw+uHt4H9w9vA/+Qg9fHmgVNqB8PgIAAAAASUVORK5CYII=");
            
            await client.SendAsync(new MailData()
            {
                To=new List<string>(){"pawel.worwag@gmail.com"},
                Subject = "[DailyRoutine] Test",
                Body = "<html><body><h1>Test</h1><div><img src=\"cid:alamakota123\" style=\"border-radius: 50%;\"/></div><p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris feugiat nisl auctor finibus tempor. Donec ullamcorper mollis nunc, eu fermentum eros. Maecenas luctus ac ex at dignissim. Nullam augue est, gravida a sagittis sed, egestas in lectus. Vivamus et turpis ut turpis hendrerit convallis. Fusce eget finibus diam. Aenean tellus dui, laoreet ac aliquet nec, placerat in nisi. Nulla mauris nunc, efficitur nec egestas vitae, maximus et urna.</p><br/></body></html>",
                Attachments = new List<MailaDataAttachment>()
                {
                    new MailaDataAttachment()
                    {
                        Inline = true,
                        Cid = "alamakota123",
                        FileName = "unnamed.png",
                        MimeType = "image/png",
                        Data = file
                    },
                    new MailaDataAttachment()
                    {
                        FileName = "Attachment.txt",
                        MimeType = "text/plain",
                        Data = Encoding.UTF8.GetBytes("Ala ma kota.")
                    }
                }
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
