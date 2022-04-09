using DLL.Context;
using DLL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict.Abstractions;

namespace APIA.StartupExtension
{
    public static class AddIdentityDependency
    {
        public static IServiceCollection AddApplicationIdentitySetup(this IServiceCollection services)
        {
            // Register the Identity services.
           
            return services;
        }

        public static IApplicationBuilder AddAuthorizationSertup(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
    }
}