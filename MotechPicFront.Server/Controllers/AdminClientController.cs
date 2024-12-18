using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotechPicFront.Server.Models;
using MotechPicFront.Server.Services;

namespace MotechPicFront.Server.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("clients")]
    public class AdminClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public AdminClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var products = await _clientService.GetAllClientsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            var product = await _clientService.GetClientByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            await _clientService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Validate the input object

            if (id != client.Id)
                return BadRequest("Product ID mismatch.");

            var existingClient = await _clientService.GetClientByIdAsync(id);
            if (existingClient == null)
                return NotFound(); // Return 404 if the product does not exist

            // Perform the update
            await _clientService.UpdateClientAsync(client);

            return Ok(client); // Return 200 OK with the updated product
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
