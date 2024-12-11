using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialsController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public IEnumerable<Material> GetAll()
        {
            return _materialService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Material> GetById(int id)
        {
            var material = _materialService.GetById(id);
            if (material == null)
                return NotFound();
            return material;
        }

        [HttpPost]
        public ActionResult Create(Material material)
        {
            _materialService.Create(material);
            return CreatedAtAction(nameof(GetById), new { id = material.MaterialID }, material);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Material material)
        {
            if (id != material.MaterialID)
                return BadRequest();
            if (_materialService.Update(material))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_materialService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}