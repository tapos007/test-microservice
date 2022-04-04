using Microsoft.AspNetCore.Mvc;

namespace APIAuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuhtorizationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index()
        {
            return Ok(" this url genreate token");
        }
    }
}