using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IEnumerable<Department> GetAll()
        {
            return _departmentService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var department = _departmentService.GetById(id);
            if (department == null)
                return NotFound();
            return department;
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            _departmentService.Create(department);
            return CreatedAtAction(nameof(GetById), new { id = department.DepartmentID }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Department department)
        {
            if (id != department.DepartmentID)
                return BadRequest();
            if (_departmentService.Update(department))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_departmentService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}