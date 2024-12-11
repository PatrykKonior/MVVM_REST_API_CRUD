using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly InvoiceService _invoiceService;

        public InvoicesController(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IEnumerable<Invoice> GetAll()
        {
            return _invoiceService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Invoice> GetById(int id)
        {
            var invoice = _invoiceService.GetById(id);
            if (invoice == null)
                return NotFound();
            return invoice;
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            _invoiceService.Create(invoice);
            return CreatedAtAction(nameof(GetById), new { id = invoice.InvoiceID }, invoice);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceID)
                return BadRequest();
            if (_invoiceService.Update(invoice))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_invoiceService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}