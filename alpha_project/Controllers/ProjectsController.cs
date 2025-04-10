using Business.Dtos;
using Business.Services;
using Microsoft.AspNetCore.Http;
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
            var createdProject = await _projectService.CreateProjectAsync(form);

            if (createdProject is null)
                return BadRequest("Unable to create project.");

            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
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
            var project = await _projectService.GetProjectByIdAsync(id);

            if (project is null)
                return NotFound($"Project with ID '{id}' was not found.");

            return Ok(project);
        }

    }
}
