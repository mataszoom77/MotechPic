using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Services
{
    public interface ISparePartRequestService
    {
        Task<IEnumerable<SparePartRequest>> GetAllRequestsAsync();
        Task<SparePartRequest?> GetRequestByIdAsync(int id);
        Task AddRequestAsync(SparePartRequest request);
        Task UpdateRequestAsync(SparePartRequest request);
        Task DeleteRequestAsync(int id);
    }
}
