using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Models;

namespace Business.Factories
{
    public class AddProjectFormMapper : IFormToModelMapper<AddProjectForm, ProjectModel>
    {
        public ProjectModel MapToModel(AddProjectForm projectForm)
        {
            return new ProjectModel
            {
                Id = Guid.NewGuid().ToString(),
                ProjectName = projectForm.ProjectName,
                Description = projectForm.Description,
                StartDate = projectForm.StartDate,
                EndDate = projectForm.EndDate,
                Budget = projectForm.Budget,
                Client = new ClientModel { Id = projectForm.ClientId },
                User = new UserModel { Id = projectForm.UserId },
                Status = new StatusModel { Id = projectForm.StatusId }
            };
        }
    }
}
