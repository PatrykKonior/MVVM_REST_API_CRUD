using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeLogsController : ControllerBase
    {
        private readonly TimeLogsService _timeLogsService;

        public TimeLogsController(TimeLogsService timeLogsService)
        {
            _timeLogsService = timeLogsService;
        }

        [HttpGet]
        public IEnumerable<TimeLog> GetAll()
        {
            return _timeLogsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TimeLog> GetById(int id)
        {
            var timeLog = _timeLogsService.GetById(id);
            if (timeLog == null)
                return NotFound();
            return timeLog;
        }

        [HttpPost]
        public ActionResult Create(TimeLog timeLog)
        {
            _timeLogsService.Create(timeLog);
            return CreatedAtAction(nameof(GetById), new { id = timeLog.TimeLogID }, timeLog);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TimeLog timeLog)
        {
            if (id != timeLog.TimeLogID)
                return BadRequest();
            if (_timeLogsService.Update(timeLog))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_timeLogsService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}