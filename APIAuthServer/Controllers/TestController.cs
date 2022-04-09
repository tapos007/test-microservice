using System.Collections.Generic;
using System.Threading.Tasks;
using DLL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;

namespace APIAuthServer.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly IOpenIddictApplicationManager _applicationManager;
        private readonly UserManager<ApplicationUser> _usrMgr;
        private readonly RoleManager<IdentityRole> _roleManager;

        public TestController(IOpenIddictApplicationManager applicationManager,
            UserManager<ApplicationUser> usrMgr,
            RoleManager<IdentityRole> roleManager)
        {
            _applicationManager = applicationManager;
            _usrMgr = usrMgr;
            _roleManager = roleManager;
        }

        [HttpGet("create-client")]
        public async Task<IActionResult> Index()
        {
            if (await _applicationManager.FindByClientIdAsync("android") ==null)
            {
                await _applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "android",
                    ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
                    DisplayName = "My Android Application",
                    Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Token,
                        OpenIddictConstants.Permissions.GrantTypes.Password,
                        OpenIddictConstants.Permissions.GrantTypes.RefreshToken,
                    }
                });
            }
            
            if (await _applicationManager.FindByClientIdAsync("api-a") ==null)
            {
                await _applicationManager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "api-a",
                    ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
                    DisplayName = "My API A Application",
                    Permissions =
                    {
                        OpenIddictConstants.Permissions.Endpoints.Introspection
                    }
                });
            }
            return Ok("done");
        }
        
        
        [HttpGet("create-user")]
        public async Task<IActionResult> Create()
        {

            await _roleManager.CreateAsync(new IdentityRole("customer"));
            var userList = new List<string>()
            {
                "tapos.aa@gmail.com",
                "sanjib@r-cis.com",
                "sumon@r-cis.com"
            };

            foreach (var user in userList)
            {
                var appUser = new ApplicationUser
                {
                    UserName = user,
                    Email = user
                };
 
                IdentityResult result = await _usrMgr.CreateAsync(appUser, "Rcis123$..");
                if (result.Succeeded)
                    await _usrMgr.AddToRoleAsync(appUser, "customer");
                else
                {

                }
            }

            return Ok("good");
        }
    }
}