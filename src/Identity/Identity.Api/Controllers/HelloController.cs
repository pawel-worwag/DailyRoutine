using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS1591

namespace Identity.Api.Controllers
{
    [Route("api/identity-management/")]
    [ApiController]
    public class HelloController : ControllerBase
    {

        private readonly IMailBusProducer _mail;
        public HelloController(IMailBusProducer mail)
        {
            _mail = mail;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }
        
        [HttpGet("/test")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> ReadFileTest()
        {
            await _mail.SendMailAsync(EmailType.HELLO,new List<string>{"jan.testowy@mail.com"},new Dictionary<string, string>()
            {
                {"aa","bb"},
                {"bb","cc"}
            });
            return Ok();
        }
    }
}
