using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DailyRoutine.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/calendar-management/dictionaries")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        /// <summary>
        /// List of allowed entry types
        /// </summary>
        /// <returns></returns>
        [HttpGet("entry-types")]
        public IActionResult GetAllowedEntryTypes()
        {
            return Ok();
        }
        
        /// <summary>
        /// List of allowed section types
        /// </summary>
        /// <returns></returns>
        [HttpGet("section-types")]
        public IActionResult GetAllowedSectionsTypes()
        {
            return Ok();
        }
    }
}
