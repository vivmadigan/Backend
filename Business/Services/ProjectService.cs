using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;
using Business.Factories;
using Business.Models;
using Business.Repos;
using Data.Enitities;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<ProjectModel?> CreateProjectAsync(AddProjectForm formData);
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<ProjectModel?> GetProjectByIdAsync(string id);
    }

    public class ProjectService(
        IProjectRepo projectRepository,
        IFormToModelMapper<AddProjectForm, ProjectModel> formMapper) : IProjectService
    {
        private readonly IProjectRepo _projectRepo = projectRepository;
        private readonly IFormToModelMapper<AddProjectForm, ProjectModel> _formMapper = formMapper;
        public async Task<ProjectModel?> CreateProjectAsync(AddProjectForm formData)
        {
            if (formData is null)
                return null;

            // Use mapper to get a ProjectModel from the AddProjectForm
            var projectModel = _formMapper.MapToModel(formData);

            // Use repo's internal mapper (ProjectModel → ProjectEntity)
            await _projectRepo.AddAsync(projectModel);

            // Return newly created project including all navigation properties
            return await _projectRepo.GetAsync(
                p => p.Id == projectModel.Id,
                p => p.Client,
                p => p.User,
                p => p.Status
            );
        }

        public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
        {
            return await _projectRepo.GetAllAsync(
                sortBy: p => p.Created,
                orderByDescending: true,
                includes: new Expression<Func<ProjectEntity, object>>[]
                {
                    p => p.Client,
                    p => p.User,
                    p => p.Status
                });
        }

        public async Task<ProjectModel?> GetProjectByIdAsync(string id)
        {
            return await _projectRepo.GetAsync(
                p => p.Id == id,
                p => p.Client,
                p => p.User,
                p => p.Status);
        }
    }
}

