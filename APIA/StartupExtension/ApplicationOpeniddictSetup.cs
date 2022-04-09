using DLL.Context;
using Microsoft.Extensions.DependencyInjection;

namespace APIA.StartupExtension
{
    public static class ApplicationOpeniddictSetup
    {
        public static IServiceCollection AddApplicationOpeniddict(this IServiceCollection services)
        {
            services.AddOpenIddict()
                .AddValidation(options =>
                {

                    options.SetIssuer("https://localhost:7071");
                    //options.SetIssuer("https://localhost:5091/");

                    
                  //  options.AddAudiences("api-app");
                    // options.AddAudiences("resource_server_1");

                    // Configure the validation handler to use introspection and register the client
                    // credentials used when communicating with the remote introspection endpoint.
                    options.UseIntrospection()
                        .SetClientId("api-a")
                        .SetClientSecret("388D45FA-B36B-4988-BA59-B187D329C207");
                    
                    

                    // Register the System.Net.Http integration.
                    options.UseSystemNetHttp();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

                
            return services;
        }
    }
}