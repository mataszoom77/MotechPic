﻿using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(int id);
        Task AddClientAsync(Client product);
        Task UpdateClientAsync(Client product);
        Task DeleteClientAsync(int id);
    }
}
