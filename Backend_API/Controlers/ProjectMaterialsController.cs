using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectMaterialsController : ControllerBase
    {
        private readonly ProjectMaterialService _projectMaterialService;

        public ProjectMaterialsController(ProjectMaterialService projectMaterialService)
        {
            _projectMaterialService = projectMaterialService;
        }

        [HttpGet]
        public IEnumerable<ProjectMaterial> GetAll()
        {
            return _projectMaterialService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectMaterial> GetById(int id)
        {
            var projectMaterial = _projectMaterialService.GetById(id);
            if (projectMaterial == null)
                return NotFound();
            return projectMaterial;
        }

        [HttpPost]
        public ActionResult Create(ProjectMaterial projectMaterial)
        {
            _projectMaterialService.Create(projectMaterial);
            return CreatedAtAction(nameof(GetById), new { id = projectMaterial.ProjectMaterialID }, projectMaterial);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProjectMaterial projectMaterial)
        {
            if (id != projectMaterial.ProjectMaterialID)
                return BadRequest();
            if (_projectMaterialService.Update(projectMaterial))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_projectMaterialService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}