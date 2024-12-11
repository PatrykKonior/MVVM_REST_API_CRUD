using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _salesService;

        public SalesController(SalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpGet]
        public IEnumerable<Sale> GetAll()
        {
            return _salesService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Sale> GetById(int id)
        {
            var sale = _salesService.GetById(id);
            if (sale == null)
                return NotFound();
            return sale;
        }

        [HttpPost]
        public ActionResult Create(Sale sale)
        {
            _salesService.Create(sale);
            return CreatedAtAction(nameof(GetById), new { id = sale.SaleID }, sale);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Sale sale)
        {
            if (id != sale.SaleID)
                return BadRequest();
            if (_salesService.Update(sale))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_salesService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}