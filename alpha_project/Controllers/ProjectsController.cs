using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace alpha_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        // POST: api/projects
        [HttpPost]
        public async Task<IActionResult> CreateProject(AddProjectForm form)
        {
            var result= await _projectService.CreateProjectAsync(form);
            if (!result.Success)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return CreatedAtAction(nameof(GetProjectById), new { id = result.Project.Id }, result.Project);
        }

        // GET: api/projects
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjectsAsync();
            return Ok(projects);
        }

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(string id)
        {
            var result = await _projectService.GetProjectByIdAsync(id);

            if (!result.Success)
                return StatusCode(result.StatusCode, result.ErrorMessage);

            return Ok(result.Project);
        }

        // PUT: api/projects
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectForm form)
        {
            var result = await _projectService.UpdateProjectAsync(form);
            if (!result.Success)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return Ok(result.Project);
        }

        // Delete: api/projects/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            if (!result.Success)
                return StatusCode(result.StatusCode, result.ErrorMessage);
            return NoContent();
        }

    }
}
