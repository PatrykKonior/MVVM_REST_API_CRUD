using Backend_API.Models.Entities;
using Backend_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentsService _paymentsService;

        public PaymentsController(PaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDTO>> GetAll()
        {
            var payments = _paymentsService.GetAll();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public ActionResult<PaymentDTO> GetById(int id)
        {
            var payment = _paymentsService.GetById(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            _paymentsService.Create(payment);
            return CreatedAtAction(nameof(GetById), new { id = payment.PaymentID }, payment);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Payment payment)
        {
            if (id != payment.PaymentID) return BadRequest();

            if (!_paymentsService.Update(payment)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_paymentsService.Delete(id)) return NotFound();
            return NoContent();
        }
    }
}