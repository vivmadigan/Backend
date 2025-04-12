using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alpha_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(IClientService clientService) : ControllerBase
    {
        // GET: api/clients
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await clientService.GetClientsAsync();
            return Ok(clients);
        }

    }
}
