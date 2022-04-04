using Microsoft.AspNetCore.Mvc;

namespace APIB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BApplicationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("this is api B application");
        }
    }
}