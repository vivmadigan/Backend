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
    public interface IProjectRepo : IBaseRepo<ProjectEntity, ProjectModel>
    {
    }

    public class ProjectRepo(AppDbContext context, IMappingFactory<ProjectEntity, ProjectModel> mappingFactory)
        : BaseRepo<ProjectEntity, ProjectModel>(context, mappingFactory), IProjectRepo
    {

    }
}
