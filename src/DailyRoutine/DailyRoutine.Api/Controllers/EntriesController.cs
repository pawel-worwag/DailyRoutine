using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyRutine.Api.Controllers
{
    /// <summary>
    /// Get list of entries
    /// </summary>
    [Route("api/calendar-management/entries")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        /// <summary>
        /// Get list of entries
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEntries(Guid? calendarGuid = null, DateTime? date = null)
        {
            return Ok();
        }
        
        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult CreateNewEntry(Guid calendarGuid, DateTime date)
        {
            return Ok();
        }
        
        /// <summary>
        /// Add new entry
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public IActionResult GetEntryDetails(Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Update entry
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public IActionResult UpdateEntry(Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Delete entry
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("{guid}")]
        public IActionResult DeleteEntry( Guid guid)
        {
            return Ok();
        }
    }
}
