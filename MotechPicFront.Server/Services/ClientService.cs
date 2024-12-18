using MotechPicFront.Server.Models;
using MotechPicFront.Server.Repositories;

namespace MotechPicFront.Server.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _repository.GetAllClientsAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _repository.GetClientByIdAsync(id);
        }

        public async Task AddClientAsync(Client client)
        {
            await _repository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            var existingClient = await _repository.GetClientByIdAsync(client.Id);
            if (existingClient == null)
                throw new KeyNotFoundException($"Product with ID {client.Id} not found.");

            await _repository.UpdateClientAsync(client);
        }


        public async Task DeleteClientAsync(int id)
        {
            await _repository.DeleteClientAsync(id);
        }
    }
}
