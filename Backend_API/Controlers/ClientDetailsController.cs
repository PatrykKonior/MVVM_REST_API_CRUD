using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientDetailsController : ControllerBase
    {
        private readonly ClientDetailsService _clientDetailsService;

        public ClientDetailsController(ClientDetailsService clientDetailsService)
        {
            _clientDetailsService = clientDetailsService;
        }

        [HttpGet]
        public IEnumerable<ClientDetail> GetAll()
        {
            return _clientDetailsService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDetail> GetById(int id)
        {
            var clientDetail = _clientDetailsService.GetById(id);
            if (clientDetail == null)
                return NotFound();
            return clientDetail;
        }

        [HttpPost]
        public ActionResult Create(ClientDetail clientDetail)
        {
            _clientDetailsService.Create(clientDetail);
            return CreatedAtAction(nameof(GetById), new { id = clientDetail.ClientDetailID }, clientDetail);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ClientDetail clientDetail)
        {
            if (id != clientDetail.ClientDetailID)
                return BadRequest();
            if (_clientDetailsService.Update(clientDetail))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_clientDetailsService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}