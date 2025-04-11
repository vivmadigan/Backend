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
using Microsoft.Identity.Client;

namespace Business.Services
{
    public interface IProjectService
    {
        Task<ProjectResult> CreateProjectAsync(AddProjectForm formData);
        Task<IEnumerable<ProjectModel>> GetProjectsAsync();
        Task<ProjectResult> GetProjectByIdAsync(string id);
        Task<ProjectResult> DeleteProjectAsync(string id);
        Task<ProjectResult> UpdateProjectAsync(UpdateProjectForm formData);
    }

    public class ProjectService(
        IProjectRepo projectRepository, IClientRepo clientRepository, IUserRepo userRepository, 
        IFormToModelMapper<AddProjectForm, ProjectModel> addFormMapper, IUpdateFormMapper<UpdateProjectForm, ProjectModel> updateFormMapper) : IProjectService
    {
        private readonly IProjectRepo _projectRepo = projectRepository;
        private readonly IFormToModelMapper<AddProjectForm, ProjectModel> _addFormMapper = addFormMapper;
        private readonly IUpdateFormMapper<UpdateProjectForm, ProjectModel> _updateFormMapper = updateFormMapper;
        private readonly IClientRepo _clientRepo = clientRepository;
        private readonly IUserRepo _userRepo = userRepository;
        public async Task<ProjectResult> CreateProjectAsync(AddProjectForm formData)
        {
            if (formData is null)
            {
                return new ProjectResult
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Form data is null."
                };
            }

            if (!await _clientRepo.ExistsAsync(c => c.Id == formData.ClientId))
            {
                return new ProjectResult
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Client not found in database."
                };
            }
            if (!await _userRepo.ExistsAsync(u => u.Id == formData.UserId))
            {
                return new ProjectResult
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "User not found in database."
                };
            }

            // Use mapper to get a ProjectModel from the AddProjectForm
            var projectModel = _addFormMapper.MapToModel(formData);

            // Use repo's internal mapper (ProjectModel → ProjectEntity)
            await _projectRepo.AddAsync(projectModel);

            // Return newly created project including all navigation properties
           var fullProject = await _projectRepo.GetAsync(
                p => p.Id == projectModel.Id,
                p => p.Client,
                p => p.User,
                p => p.Status
            );
            return new ProjectResult
            {
                Success = true,
                StatusCode = 201,
                Project = fullProject
            };
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

        public async Task<ProjectResult> GetProjectByIdAsync(string id)
        {
            var project = await _projectRepo.GetAsync(
                p => p.Id == id,
                p => p.Client,
                p => p.User,
                p => p.Status
            );

            if (project is null)
            {
                return new ProjectResult
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = $"Project with ID '{id}' was not found."
                };
            }

            return new ProjectResult
            {
                Success = true,
                StatusCode = 200,
                Project = project
            };
        }

        public async Task<ProjectResult> UpdateProjectAsync(UpdateProjectForm formData)
        {
            {
                if (formData is null)
                    return new ProjectResult { Success = false, StatusCode = 400, ErrorMessage = "Form data is null." };

                var existingProject = await _projectRepo.GetAsync(
                    p => p.Id == formData.Id,
                    p => p.Client,
                    p => p.User,
                    p => p.Status
                );

                if (existingProject is null)
                    return new ProjectResult { Success = false, StatusCode = 404, ErrorMessage = $"Project with ID '{formData.Id}' not found." };

                // Apply changes *onto* the already tracked object
                _updateFormMapper.MapToExistingModel(formData, existingProject);

                await _projectRepo.UpdateAsync(existingProject);

                var updatedProject = await _projectRepo.GetAsync(
                    p => p.Id == existingProject.Id,
                    p => p.Client,
                    p => p.User,
                    p => p.Status
                );

                return new ProjectResult
                {
                    Success = true,
                    StatusCode = 200,
                    Project = updatedProject
                };
            }
        }
        public async Task<ProjectResult> DeleteProjectAsync(string id)
        {
            // Include navigation properties to avoid null reference errors during mapping
            var project = await _projectRepo.GetAsync(
                p => p.Id == id,
                p => p.Client,
                p => p.User,
                p => p.Status
            );
            if (project is null)
            {
                return new ProjectResult
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = $"Project with ID '{id}' was not found."
                };
            }
            await _projectRepo.DeleteAsync(p => p.Id == id);
            return new ProjectResult
            {
                Success = true,
                StatusCode = 204
            };
        }
    }
}

