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
                ClientId = model.Client.Id,
                UserId = model.User.Id,
                StatusId = model.Status.Id

            };
        }

        public ProjectModel MapToModel(ProjectEntity entity)
        {
            // Maps a ProjectEntity to a ProjectModel, including safe handling of null navigation properties
            return new ProjectModel
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Budget = entity.Budget,

                // Defensive check in case navigation properties were not eagerly loaded
                Client = entity.Client != null ? new ClientModel
                {
                    Id = entity.ClientId,
                    ClientName = entity.Client.ClientName,
                } : null,

                User = entity.User != null ? new UserModel
                {
                    Id = entity.UserId,
                    UserName = entity.User.UserName
                } : null,

                Status = entity.Status != null ? new StatusModel
                {
                    Id = entity.StatusId,
                    StatusName = entity.Status.StatusName
                } : null
            };
        }
    }
}
