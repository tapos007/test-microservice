using Microsoft.AspNetCore.Mvc;

namespace APIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AApplicationController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("this is api A application");
        }
    }
}