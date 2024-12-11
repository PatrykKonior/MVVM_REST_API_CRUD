using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpensesController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public IEnumerable<Expense> GetAll()
        {
            return _expenseService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> GetById(int id)
        {
            var expense = _expenseService.GetById(id);
            if (expense == null)
                return NotFound();
            return expense;
        }

        [HttpPost]
        public ActionResult Create(Expense expense)
        {
            _expenseService.Create(expense);
            return CreatedAtAction(nameof(GetById), new { id = expense.ExpenseID }, expense);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Expense expense)
        {
            if (id != expense.ExpenseID)
                return BadRequest();
            if (_expenseService.Update(expense))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_expenseService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}