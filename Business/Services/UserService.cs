using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Business.Repos;
using Data.Enitities;

namespace Business.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
    }

    public class UserService(IUserRepo userRepo) : IUserService
    {
        private readonly IUserRepo _userRepo = userRepo;

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await _userRepo.GetAllAsync(
                sortBy: u => u.UserName,
                orderByDescending: false
            );
        }

    }
}
