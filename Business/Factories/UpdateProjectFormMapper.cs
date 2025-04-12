using Business.Dtos;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories
{
    public class UpdateProjectFormMapper : IUpdateFormMapper<UpdateProjectForm, ProjectModel>
    {
        public ProjectModel MapToUpdateModel(UpdateProjectForm form)
        {
            return new ProjectModel
            {
                Id = form.Id,
                ProjectName = form.ProjectName,
                Description = form.Description,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Budget = form.Budget,
                Client = new ClientModel { Id = form.ClientId },
                User = new UserModel { Id = form.UserId },
                Status = new StatusModel { Id = form.StatusId }
            };
        }
    }
}
