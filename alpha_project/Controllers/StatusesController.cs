using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alpha_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController(IStatusService statusService) : ControllerBase
    {
        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetStatuses()
        {
            var statuses = await statusService.GetStatusesAsync();
            return Ok(statuses);
        }
    }
}
