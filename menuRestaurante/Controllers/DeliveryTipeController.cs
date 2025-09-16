using Application.Interfaces.InterfaceDeliveryType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace menuRestaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTipeController : ControllerBase
    {
        private readonly IServiceDeliveryTypeGet _serviceDeliveryTypeGet;

        public DeliveryTipeController(IServiceDeliveryTypeGet serviceDeliveryTypeGet)
        {
            _serviceDeliveryTypeGet = serviceDeliveryTypeGet;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDeliveryTypes()
        {
            var deliveryTypes = await _serviceDeliveryTypeGet.GetAllDeliveryTypes();
            return new JsonResult(deliveryTypes);
        }
    }
}
