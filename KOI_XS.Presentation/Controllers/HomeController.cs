
using Microsoft.AspNetCore.Mvc;

namespace KOI_XS.Presentation.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome to KOI_XS API!");
        }
    }
}
