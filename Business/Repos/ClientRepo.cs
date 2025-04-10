using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Factories;
using Business.Models;
using Data.Contexts;
using Data.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Business.Repos
{
    public interface IClientRepo : IBaseRepo<ClientEntity, ClientModel>
    {
    }

    public class ClientRepo(AppDbContext context, IMappingFactory<ClientEntity, ClientModel> mappingFactory)
        : BaseRepo<ClientEntity, ClientModel>(context, mappingFactory), IClientRepo
    {

    }

    
}
