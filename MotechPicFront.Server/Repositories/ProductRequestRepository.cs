using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Data;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public class ProductRequestRepository : IProductRequestRepository
    {
        private readonly MotechPicContext _context;

        public ProductRequestRepository(MotechPicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductRequest>> GetAllRequestsAsync()
        {
            return await _context.ProductRequests.ToListAsync();
        }

        public async Task<ProductRequest?> GetRequestByIdAsync(int id)
        {
            return await _context.ProductRequests.FindAsync(id);
        }

        public async Task AddRequestAsync(ProductRequest request)
        {
            await _context.ProductRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestAsync(ProductRequest request)
        {
            _context.ProductRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(int id)
        {
            var request = await GetRequestByIdAsync(id);
            if (request != null)
            {
                _context.ProductRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
