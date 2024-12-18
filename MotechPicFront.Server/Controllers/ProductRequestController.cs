using Microsoft.AspNetCore.Mvc;
using MotechPicFront.Server.Models;
using MotechPicFront.Server.Services;

namespace MotechPicFront.Server.Controllers
{
    [ApiController]
    [Route("clients/{ClientID}/product-requests")]
    public class ProductRequestController : ControllerBase
    {
        private readonly IProductRequestService _requestService;
        private readonly IProductService _productService;

        public ProductRequestController(IProductRequestService requestService, IProductService productService)
        {
            _requestService = requestService;
            _productService = productService;
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
        public async Task<IActionResult> AddRequest([FromBody] ProductRequest request)
        {
            var product = await _productService.GetProductByIdAsync(request.ProductId);
            if (product == null)
            {
                return NotFound("Product Not found");
            }
            else
            {
                await _requestService.AddRequestAsync(request);
                if (request == null)
                    return CreatedAtAction(nameof(GetRequestById), new { id = request.Id }, request);
                else return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRequest(int id, [FromBody] ProductRequest request)
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
