using MotechPicFront.Server.Models;
using MotechPicFront.Server.Repositories;

namespace MotechPicFront.Server.Services
{
    public class SparePartRequestService : ISparePartRequestService
    {
        private readonly ISparePartRequestRepository _repository;

        public SparePartRequestService(ISparePartRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SparePartRequest>> GetAllRequestsAsync()
        {
            return await _repository.GetAllRequestsAsync();
        }

        public async Task<SparePartRequest?> GetRequestByIdAsync(int id)
        {
            return await _repository.GetRequestByIdAsync(id);
        }

        public async Task AddRequestAsync(SparePartRequest request)
        {
            await _repository.AddRequestAsync(request);
        }

        public async Task UpdateRequestAsync(SparePartRequest request)
        {
            await _repository.UpdateRequestAsync(request);
        }

        public async Task DeleteRequestAsync(int id)
        {
            await _repository.DeleteRequestAsync(id);
        }
    }
}
