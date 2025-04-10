using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Data.Enitities;

namespace Business.Factories
{
    public class UserMappingFactory : IMappingFactory<UserEntity, UserModel>
    {
        public UserEntity MapToEntity(UserModel model)
        {
            return new UserEntity
            {
                Id = model.Id,
                UserName = model.UserName,
            };
        }
        public UserModel MapToModel(UserEntity entity)
        {
            return new UserModel
            {
                Id = entity.Id,
                UserName = entity.UserName,
            };
        }
    }
}
