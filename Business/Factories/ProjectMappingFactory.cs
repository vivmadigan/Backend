using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using Data.Enitities;

namespace Business.Factories
{
    public class ProjectMappingFactory : IMappingFactory<ProjectEntity, ProjectModel>
    {
        public ProjectEntity MapToEntity(ProjectModel model)
        {
            return new ProjectEntity
            {
                Id = model.Id,
                ProjectName = model.ProjectName,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Budget = model.Budget,
                ClientId = model.Client?.Id,
                UserId = model.User?.Id,
                StatusId = model.Status?.Id ?? 0

            };
        }

        public ProjectModel MapToModel(ProjectEntity entity)
        {
            return new ProjectModel
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Budget = entity.Budget,
                Client = new ClientModel
                {
                    Id = entity.ClientId,
                    ClientName = entity.Client.ClientName,
                },
                User = new UserModel
                {
                    Id = entity.UserId,
                    UserName = entity.User.UserName
                },
                Status = new StatusModel
                {
                    Id = entity.StatusId,
                    StatusName = entity.Status.StatusName
                }
            };
        }
    }
}
