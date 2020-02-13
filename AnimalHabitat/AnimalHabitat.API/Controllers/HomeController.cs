using Microsoft.AspNetCore.Mvc;

namespace AnimalHabitat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return this.Ok("The application has started...");
        }
    }
}