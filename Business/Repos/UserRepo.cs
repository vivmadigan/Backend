using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Factories;
using Business.Models;
using Data.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Business.Repos
{
    public interface IUserRepo : IBaseRepo<UserEntity, UserModel>
    {
    }

    public class UserRepo(DbContext context, IMappingFactory<UserEntity, UserModel> mappingFactory)
        : BaseRepo<UserEntity, UserModel>(context, mappingFactory), IUserRepo
    {}
}
