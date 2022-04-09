using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace APIA.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {
        

        

        [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        [HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            var ttt = User;
            

            return Ok("ok");
        }
        
        // [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme,Roles = "admin,customer")]
        // [HttpGet("message-others")]
        // public async Task<IActionResult> GetMessageOthers()
        // {
        //     var ttt = User;
        //     var user = await _userManager.GetUserAsync(User);
        //     if (user == null)
        //     {
        //         return BadRequest();
        //     }
        //
        //     return Ok($"{user.UserName} has been successfully authenticated.");
        // }
    }
}