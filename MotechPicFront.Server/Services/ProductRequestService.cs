using MotechPicFront.Server.Models;
using MotechPicFront.Server.Repositories;

namespace MotechPicFront.Server.Services
{
    public class ProductRequestService : IProductRequestService
    {
        private readonly IProductRequestRepository _repository;

        public ProductRequestService(IProductRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductRequest>> GetAllRequestsAsync()
        {
            return await _repository.GetAllRequestsAsync();
        }

        public async Task<ProductRequest?> GetRequestByIdAsync(int id)
        {
            return await _repository.GetRequestByIdAsync(id);
        }

        public async Task AddRequestAsync(ProductRequest request)
        {
            await _repository.AddRequestAsync(request);
        }

        public async Task UpdateRequestAsync(ProductRequest request)
        {
            await _repository.UpdateRequestAsync(request);
        }

        public async Task DeleteRequestAsync(int id)
        {
            await _repository.DeleteRequestAsync(id);
        }
    }
}
