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
        public void MapToExistingModel(UpdateProjectForm form, ProjectModel model)
        {
            model.ProjectName = form.ProjectName;
            model.Description = form.Description;
            model.StartDate = form.StartDate;
            model.EndDate = form.EndDate;
            model.Budget = form.Budget;
            model.Client = new ClientModel { Id = form.ClientId };
            model.User = new UserModel { Id = form.UserId };
            model.Status = new StatusModel { Id = form.StatusId };
        }
    }
}
