using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Repos;

namespace Business.Services
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel>> GetStatusesAsync();
    }

    public class StatusService(IStatusRepo statusRepo) : IStatusService
    {
        private readonly IStatusRepo _statusRepo = statusRepo;

        public async Task<IEnumerable<StatusModel>> GetStatusesAsync()
        {
            return await _statusRepo.GetAllAsync(
                sortBy: s => s.Id,
                orderByDescending: false
            );
        }
    }
}
