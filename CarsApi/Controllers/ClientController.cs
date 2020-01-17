using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarsApi.Models;
using CarsApi.Services;

namespace CarsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientservice;

        public ClientController(ClientService clientservice)
        {
            _clientservice = clientservice;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() =>
            _clientservice.Get();

        [HttpGet("{id:length(24)}", Name = "ClientDetails")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientservice.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client cli)
        {
            _clientservice.Create(cli);

            return CreatedAtRoute("ClientDetails" +
                "", new { id = cli.Id.ToString() }, cli);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Client client)
        {
            var cli = _clientservice.Get();

            if (cli == null)
            {
                return NotFound();
            }

            _clientservice.Update(id, client);

            return NoContent();
        }

        [HttpDelete("id:length(24)")]
        public IActionResult Delete(string id)
        {
            var client = _clientservice.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _clientservice.Removed(client.Id);

            return NoContent();
        }

    }
}
