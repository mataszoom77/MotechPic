using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotechPicFront.Server.Models;
using MotechPicFront.Server.Services;

namespace MotechPicFront.Server.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    [Route("admin/products/{productId}/spare-parts")]
    public class SparePartController : ControllerBase
    {
        private readonly ISparePartService _sparePartService;
        private readonly IProductService _ProductService;

        public SparePartController(ISparePartService sparePartService, IProductService productService)
        {
            _sparePartService = sparePartService;
            _ProductService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpareParts(int productId)
        {
            var spareParts = await _sparePartService.GetAllSparePartsAsync(productId);
            if (!spareParts.Any()) { 
                return NotFound();
            }
            return Ok(spareParts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSparePartById(int id)
        {
            var sparePart = await _sparePartService.GetSparePartByIdAsync(id);
            if (sparePart == null)
                return NotFound();

            return Ok(sparePart);
        }

        [HttpPost]
        public async Task<IActionResult> AddSparePart(int productId, [FromBody] SparePart sparePart)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Validate input

            // Check if the product exists
            var product = await _ProductService.GetProductByIdAsync(productId);
            if (product == null)
                return NotFound("Product with this ID does not exist");

            // Associate the spare part with the product
            sparePart.ProductId = productId;

            // Add the spare part via the service layer
            var createdSparePart = await _sparePartService.AddSparePartAsync(sparePart);

            // Return the created resource
            return CreatedAtAction(nameof(GetSparePartById), new { productId, id = createdSparePart.Id }, createdSparePart);
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSparePart(int id, [FromBody] SparePart sparePart)
        {
            //if (id != sparePart.Id)
            //    return BadRequest();
            sparePart.Id = id;
            await _sparePartService.UpdateSparePartAsync(sparePart);
            return Ok(sparePart);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(int id)
        {
            await _sparePartService.DeleteSparePartAsync(id);
            return NoContent();
        }
    }
}
