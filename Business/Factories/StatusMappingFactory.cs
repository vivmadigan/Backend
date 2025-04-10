using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Data.Enitities;

namespace Business.Factories
{
    public class StatusMappingFactory : IMappingFactory<StatusEntity, StatusModel>
    {
        public StatusEntity MapToEntity(StatusModel model)
        {
            return new StatusEntity()
            {
                Id = model.Id,
                StatusName = model.StatusName,
            };
        }

        public StatusModel MapToModel(StatusEntity entity)
        {
            return new StatusModel()
            {
                Id = entity.Id,
                StatusName = entity.StatusName,
            };
        }
    }
}
