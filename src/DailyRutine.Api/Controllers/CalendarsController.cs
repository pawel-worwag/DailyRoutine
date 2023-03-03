using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyRutine.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/calendar-management/calendars")]
    [ApiController]
    public class CalendarsController : ControllerBase
    {
        /// <summary>
        /// Get list of created calendars
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCalendarsList(int take = 50, int skip = 0)
        {
            return Ok();
        }

        /// <summary>
        /// Create new calendar
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult AddNewCalendar()
        {
            return Ok();
        }

        /// <summary>
        /// Get calendar details
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public IActionResult GetCalendarDetails(Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Update calendar definition
        /// </summary>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public IActionResult UpdateCalendar(Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Delete calendar
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("{guid}")]
        public IActionResult DeleteCalendar(Guid guid)
        {
            return Ok();
        }
    }
}
