using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Data.Enitities;

namespace Business.Factories
{
    public class ClientMappingFactory : IMappingFactory<ClientEntity, ClientModel>
    {
        public ClientEntity MapToEntity(ClientModel model)
        {
            return new ClientEntity()
            {
                Id = model.Id,
                ClientName = model.ClientName,
            };
        }

        public ClientModel MapToModel(ClientEntity entity)
        {
            return new ClientModel()
            {
                Id = entity.Id,
                ClientName = entity.ClientName,
            };
        }

    }
}
