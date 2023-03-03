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
    [Route("api/calendar-management/calendars/{calendarGuid}/pages/{date}")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        /// <summary>
        /// Get calendar page
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetCalendarPage(Guid calendarGuid, DateTime date)
        {
            return Ok();
        }

        /// <summary>
        /// Get list of entries
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet("entries")]
        public IActionResult GetEntries(Guid calendarGuid, DateTime date)
        {
            return Ok();
        }
        
        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPut("entries")]
        public IActionResult CreateNewEntry(Guid calendarGuid, DateTime date)
        {
            return Ok();
        }
        
        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("entries/{guid}")]
        public IActionResult GetEntryDetails(Guid calendarGuid, DateTime date, Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("entries/{guid}")]
        public IActionResult UpdateEntry(Guid calendarGuid, DateTime date, Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Delete entry
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("entries/{guid}")]
        public IActionResult DeleteEntry(Guid calendarGuid, DateTime date, Guid guid)
        {
            return Ok();
        }
    }
}
