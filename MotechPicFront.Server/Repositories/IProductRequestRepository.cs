using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public interface IProductRequestRepository
    {
        Task<IEnumerable<ProductRequest>> GetAllRequestsAsync();
        Task<ProductRequest?> GetRequestByIdAsync(int id);
        Task AddRequestAsync(ProductRequest request);
        Task UpdateRequestAsync(ProductRequest request);
        Task DeleteRequestAsync(int id);
    }
}
