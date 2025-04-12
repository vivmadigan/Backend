using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Repos;

namespace Business.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientModel>> GetClientsAsync();
    }

    public class ClientService(IClientRepo clientRepo) : IClientService
    {
        private readonly IClientRepo _clientRepo = clientRepo;

        public async Task<IEnumerable<ClientModel>> GetClientsAsync()
        {
            return await _clientRepo.GetAllAsync(
                sortBy: c => c.ClientName,
                orderByDescending: false
            );
        }

    }
}
