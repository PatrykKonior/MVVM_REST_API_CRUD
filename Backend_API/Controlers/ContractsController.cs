using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractsController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public IEnumerable<Contract> GetAll()
        {
            return _contractService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Contract> GetById(int id)
        {
            var contract = _contractService.GetById(id);
            if (contract == null)
                return NotFound();
            return contract;
        }

        [HttpPost]
        public ActionResult Create(Contract contract)
        {
            _contractService.Create(contract);
            return CreatedAtAction(nameof(GetById), new { id = contract.ContractID }, contract);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Contract contract)
        {
            if (id != contract.ContractID)
                return BadRequest();
            if (_contractService.Update(contract))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_contractService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}