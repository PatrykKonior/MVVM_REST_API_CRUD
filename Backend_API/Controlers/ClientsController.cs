using Microsoft.AspNetCore.Mvc;
using Backend_API.Models.Entities;
using Backend_API.Services;
using System.Collections.Generic;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientsController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IEnumerable<Client> GetAll()
        {
            return _clientService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetById(int id)
        {
            var client = _clientService.GetById(id);
            if (client == null)
                return NotFound();
            return client;
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            _clientService.Create(client);
            return CreatedAtAction(nameof(GetById), new { id = client.ClientID }, client);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Client client)
        {
            if (id != client.ClientID)
                return BadRequest();
            if (_clientService.Update(client))
                return NoContent();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_clientService.Delete(id))
                return NoContent();
            return NotFound();
        }
    }
}