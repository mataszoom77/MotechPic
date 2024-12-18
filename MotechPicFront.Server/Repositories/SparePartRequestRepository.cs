using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Data;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public class SparePartRequestRepository : ISparePartRequestRepository
    {
        private readonly MotechPicContext _context;

        public SparePartRequestRepository(MotechPicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SparePartRequest>> GetAllRequestsAsync()
        {
            return await _context.SparePartRequests.ToListAsync();
        }

        public async Task<SparePartRequest?> GetRequestByIdAsync(int id)
        {
            return await _context.SparePartRequests.FindAsync(id);
        }

        public async Task AddRequestAsync(SparePartRequest request)
        {
            await _context.SparePartRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRequestAsync(SparePartRequest request)
        {
            _context.SparePartRequests.Update(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(int id)
        {
            var request = await GetRequestByIdAsync(id);
            if (request != null)
            {
                _context.SparePartRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
