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
        public ActionResult<IEnumerable<ProjectDTO>> GetAll()
        {
            var projects = _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDTO> GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public ActionResult Create(Project project)
        {
            // Weryfikuj poprawność ClientID i ManagerID, jeśli zostały przesłane
            if (project.ClientID.HasValue)
            {
                var client = _projectService.GetClientById(project.ClientID.Value);
                if (client == null)
                {
                    return BadRequest(new { error = "Invalid ClientID." });
                }

                project.Client = client; // Przypisz obiekt nawigacyjny
            }

            if (project.ManagerID.HasValue)
            {
                var manager = _projectService.GetManagerById(project.ManagerID.Value);
                if (manager == null)
                {
                    return BadRequest(new { error = "Invalid ManagerID." });
                }

                project.Manager = manager; // Przypisz obiekt nawigacyjny
            }

            _projectService.Create(project);
            return CreatedAtAction(nameof(GetById), new { id = project.ProjectID }, project);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            if (id != project.ProjectID)
                return BadRequest();

            if (project.ClientID.HasValue)
            {
                var client = _projectService.GetClientById(project.ClientID.Value);
                if (client == null)
                {
                    return BadRequest(new { error = "Invalid ClientID." });
                }

                project.Client = client;
            }

            if (project.ManagerID.HasValue)
            {
                var manager = _projectService.GetManagerById(project.ManagerID.Value);
                if (manager == null)
                {
                    return BadRequest(new { error = "Invalid ManagerID." });
                }

                project.Manager = manager;
            }

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
