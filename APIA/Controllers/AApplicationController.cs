using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace APIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AApplicationController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet]
        public IActionResult Index()
        {
            var abc = User;
            return Ok("this is api A application");
        }
    }
}