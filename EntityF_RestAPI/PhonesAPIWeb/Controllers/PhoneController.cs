using Microsoft.AspNetCore.Mvc;
using PhonesAPIWeb.Service;

namespace PhonesAPIWeb.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly PhoneService phoneService;
        private readonly IphoneService iphoneService;
        private readonly SamsungService samsungService;

        public PhoneController(PhoneService phoneService, IphoneService iphoneService, SamsungService samsungService)
        {
            this.phoneService = phoneService;
            this.iphoneService = iphoneService;
            this.samsungService = samsungService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(phoneService.ObtenerTodos());
            }
            catch(ApplicationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
