using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Services
{
    public interface ISparePartService
    {
        Task<IEnumerable<SparePart>> GetAllSparePartsAsync(int productId);
        Task<SparePart?> GetSparePartByIdAsync(int id);
        Task<SparePart> AddSparePartAsync(SparePart sparePart);
        Task UpdateSparePartAsync(SparePart sparePart);
        Task DeleteSparePartAsync(int id);
    }
}
