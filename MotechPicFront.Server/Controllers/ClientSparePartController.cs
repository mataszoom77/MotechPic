using Microsoft.AspNetCore.Mvc;
using MotechPicFront.Server.Models;
using MotechPicFront.Server.Services;

namespace MotechPicFront.Server.Controllers
{
    [ApiController]
    [Route("clients/products/{productId}/spare-parts")]
    public class ClientSparePartController : ControllerBase
    {
        private readonly ISparePartService _sparePartService;

        public ClientSparePartController(ISparePartService sparePartService)
        {
            _sparePartService = sparePartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpareParts(int productId)
        {
            var spareParts = await _sparePartService.GetAllSparePartsAsync(productId);
            if (spareParts == null)
            {
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
    }
}
