using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Data;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MotechPicContext _context;

        public ClientRepository(MotechPicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client?> GetClientByIdAsync(int id)
        {
            return await _context.Clients
                .AsNoTracking() // Prevent EF Core from tracking this instance
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(Client client)
        {
            var existingProduct = await _context.Clients.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == client.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException($"Client with ID {client.Id} not found.");

            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteClientAsync(int id)
        {
            var client = await GetClientByIdAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
