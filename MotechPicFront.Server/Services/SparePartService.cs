using MotechPicFront.Server.Models;
using MotechPicFront.Server.Repositories;

namespace MotechPicFront.Server.Services
{
    public class SparePartService : ISparePartService
    {
        private readonly ISparePartRepository _repository;

        public SparePartService(ISparePartRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SparePart>> GetAllSparePartsAsync(int productId)
        {
            return await _repository.GetAllSparePartsAsync(productId);
        }

        public async Task<SparePart?> GetSparePartByIdAsync(int id)
        {
            return await _repository.GetSparePartByIdAsync(id);
        }

        public async Task<SparePart> AddSparePartAsync(SparePart sparePart)
        {
            return await _repository.AddSparePartAsync(sparePart); // Return the created spare part
        }


        public async Task UpdateSparePartAsync(SparePart sparePart)
        {
            await _repository.UpdateSparePartAsync(sparePart);
        }

        public async Task DeleteSparePartAsync(int id)
        {
            await _repository.DeleteSparePartAsync(id);
        }
    }
}
