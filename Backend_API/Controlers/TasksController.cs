using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskssController : ControllerBase
    {
        private readonly TasksService _taskService;

        public TaskssController(TasksService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IEnumerable<Tasks> GetAll()
        {
            return _taskService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Tasks> GetById(int id)
        {
            var tasks = _taskService.GetById(id);
            if (tasks == null)
                return NotFound();
            return tasks;
        }

        [HttpPost]
        public ActionResult Create(Tasks tasks)
        {
            _taskService.Create(tasks);
            return CreatedAtAction(nameof(GetById), new { id = tasks.TasksID }, tasks);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Tasks tasks)
        {
            if (id != tasks.TasksID)
                return BadRequest();
            if (_taskService.Update(tasks))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_taskService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}