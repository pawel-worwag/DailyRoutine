using Microsoft.AspNetCore.Mvc;

namespace DailyRutine.Api.Controllers;

/// <summary>
/// 
/// </summary>
[Route("api/calendar-management")]
[ApiController]
public class HelloController : ControllerBase
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}