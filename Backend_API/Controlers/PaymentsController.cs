using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public IEnumerable<Payment> GetAll()
        {
            return _paymentService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Payment> GetById(int id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
                return NotFound();
            return payment;
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            _paymentService.Create(payment);
            return CreatedAtAction(nameof(GetById), new { id = payment.PaymentID }, payment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Payment payment)
        {
            if (id != payment.PaymentID)
                return BadRequest();
            if (_paymentService.Update(payment))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_paymentService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}