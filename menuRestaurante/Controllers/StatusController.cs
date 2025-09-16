using Application.Interfaces.InterfaceStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menuRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IServiceStatusGet serviceStatusGet;

        public StatusController(IServiceStatusGet serviceStatusGet)
        {
            this.serviceStatusGet = serviceStatusGet;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatuses()
        {
            var statuses = await serviceStatusGet.GetAllStatuses();
            return new JsonResult(statuses);
        }
    }
}
