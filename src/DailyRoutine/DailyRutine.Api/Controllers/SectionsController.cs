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
    [Route("api/calendar-management/calendars/{calendarGuid}/sections")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        /// <summary>
        /// Get list of defined sections
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetSections(Guid calendarGuid)
        {
            return Ok();
        }

        /// <summary>
        /// Create new section
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult AddNewSection(Guid calendarGuid)
        {
            return Ok();
        }

        /// <summary>
        /// Get section details
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public IActionResult GetSectionDetails(Guid calendarGuid, Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Update section definition
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}")]
        public IActionResult UpdateSection(Guid calendarGuid, Guid guid)
        {
            return Ok();
        }
        
        /// <summary>
        /// Delete section definition if allowed
        /// </summary>
        /// <param name="calendarGuid"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("{guid}")]
        public IActionResult DeleteSection(Guid calendarGuid, Guid guid)
        {
            return Ok();
        }
    }
}
