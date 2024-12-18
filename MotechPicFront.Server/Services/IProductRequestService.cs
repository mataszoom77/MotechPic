using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Services
{
    public interface IProductRequestService
    {
        Task<IEnumerable<ProductRequest>> GetAllRequestsAsync();
        Task<ProductRequest?> GetRequestByIdAsync(int id);
        Task AddRequestAsync(ProductRequest request);
        Task UpdateRequestAsync(ProductRequest request);
        Task DeleteRequestAsync(int id);
    }
}
