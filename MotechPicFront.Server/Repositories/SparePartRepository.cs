using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Data;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public class SparePartRepository : ISparePartRepository
    {
        private readonly MotechPicContext _context;

        public SparePartRepository(MotechPicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SparePart>> GetAllSparePartsAsync(int productId)
        {
            return await _context.SpareParts
                .Where(sp => sp.ProductId == productId && sp != null)
                .ToListAsync();
        }

        public async Task<SparePart?> GetSparePartByIdAsync(int id)
        {
            return await _context.SpareParts.FindAsync(id);
        }

        public async Task<SparePart> AddSparePartAsync(SparePart sparePart)
        {
            await _context.SpareParts.AddAsync(sparePart);
            await _context.SaveChangesAsync();
            return sparePart;
        }

        public async Task UpdateSparePartAsync(SparePart sparePart)
        {
            _context.SpareParts.Update(sparePart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSparePartAsync(int id)
        {
            var sparePart = await GetSparePartByIdAsync(id);
            if (sparePart != null)
            {
                _context.SpareParts.Remove(sparePart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
