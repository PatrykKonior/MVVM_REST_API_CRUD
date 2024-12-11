using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleItemsController : ControllerBase
    {
        private readonly SaleItemsService _saleItemsService;

        public SaleItemsController(SaleItemsService saleItemsService)
        {
            _saleItemsService = saleItemsService;
        }

        [HttpGet]
        public IEnumerable<SaleItem> GetAll()
        {
            return _saleItemsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<SaleItem> GetById(int id)
        {
            var saleItem = _saleItemsService.GetById(id);
            if (saleItem == null)
                return NotFound();
            return saleItem;
        }

        [HttpPost]
        public ActionResult Create(SaleItem saleItem)
        {
            _saleItemsService.Create(saleItem);
            return CreatedAtAction(nameof(GetById), new { id = saleItem.SaleItemID }, saleItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SaleItem saleItem)
        {
            if (id != saleItem.SaleItemID)
                return BadRequest();
            if (_saleItemsService.Update(saleItem))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_saleItemsService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}