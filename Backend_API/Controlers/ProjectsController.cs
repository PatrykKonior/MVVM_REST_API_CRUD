using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IEnumerable<Project> GetAll()
        {
            return _projectService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null)
                return NotFound();
            return project;
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            if (project.ClientID <= 0 || project.ManagerID <= 0)
            {
                return BadRequest(new { error = "ClientID and ManagerID are required." });
            }

            var client = _projectService.GetClientById(project.ClientID);
            if (client == null)
            {
                return BadRequest(new { error = "Invalid ClientID." });
            }

            var manager = _projectService.GetManagerById(project.ManagerID);
            if (manager == null)
            {
                return BadRequest(new { error = "Invalid ManagerID." });
            }

            // Przypisanie obiektów nawigacyjnych na podstawie ID
            Console.WriteLine($"ClientID: {client.ClientID}, ManagerID: {manager.EmployeeID}");
            project.Client = client;
            project.Manager = manager;

            _projectService.Create(project);
            return CreatedAtAction(nameof(GetById), new { id = project.ProjectID }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            if (id != project.ProjectID)
                return BadRequest();

            var client = _projectService.GetClientById(project.ClientID);
            if (client == null)
            {
                return BadRequest(new { error = "Invalid ClientID." });
            }

            var manager = _projectService.GetManagerById(project.ManagerID);
            if (manager == null)
            {
                return BadRequest(new { error = "Invalid ManagerID." });
            }

            project.Client = client;
            project.Manager = manager;

            if (_projectService.Update(project))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_projectService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}
