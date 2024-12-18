using Microsoft.AspNetCore.Mvc;
using MotechPicFront.Server.Models;
using MotechPicFront.Server.Services;

namespace MotechPicFront.Server.Controllers
{
    [ApiController]
    [Route("clients/spare-part-requests")]
    public class SparePartRequestController : ControllerBase
    {
        private readonly ISparePartRequestService _requestService;

        public SparePartRequestController(ISparePartRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequests()
        {
            var requests = await _requestService.GetAllRequestsAsync();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            var request = await _requestService.GetRequestByIdAsync(id);
            if (request == null)
                return NotFound();

            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest([FromBody] SparePartRequest request)
        {
            await _requestService.AddRequestAsync(request);
            return CreatedAtAction(nameof(GetRequestById), new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] SparePartRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            await _requestService.UpdateRequestAsync(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            await _requestService.DeleteRequestAsync(id);
            return NoContent();
        }
    }
}
