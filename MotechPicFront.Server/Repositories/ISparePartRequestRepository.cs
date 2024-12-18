using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public interface ISparePartRequestRepository
    {
        Task<IEnumerable<SparePartRequest>> GetAllRequestsAsync();
        Task<SparePartRequest?> GetRequestByIdAsync(int id);
        Task AddRequestAsync(SparePartRequest request);
        Task UpdateRequestAsync(SparePartRequest request);
        Task DeleteRequestAsync(int id);
    }
}
