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
    public interface IStatusRepo : IBaseRepo<StatusEntity, StatusModel>
    {
    }

    public class StatusRepo(AppDbContext context, IMappingFactory<StatusEntity, StatusModel> mappingFactory)
        : BaseRepo<StatusEntity, StatusModel>(context, mappingFactory), IStatusRepo
    {}
}
