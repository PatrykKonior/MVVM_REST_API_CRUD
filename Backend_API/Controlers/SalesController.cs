using Backend_API.Models.Entities;
using Backend_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers;

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
    public ActionResult<IEnumerable<SaleDTO>> GetAll()
    {
        var sales = _salesService.GetAll();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public ActionResult<SaleDTO> GetById(int id)
    {
        var sale = _salesService.GetById(id);
        if (sale == null) return NotFound();
        return Ok(sale);
    }

    [HttpPost]
    public ActionResult Create(Sale sale)
    {
        if (sale.ClientID <= 0)
        {
            return BadRequest(new { error = "ClientID is required." });
        }

        // Usuń nawigacyjny obiekt Client, jeśli istnieje
        sale.Client = null;

        _salesService.Create(sale);
        return CreatedAtAction(nameof(GetById), new { id = sale.SaleID }, sale);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Sale sale)
    {
        if (id != sale.SaleID) return BadRequest();

        if (!_salesService.Update(sale)) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_salesService.Delete(id)) return NotFound();
        return NoContent();
    }
}