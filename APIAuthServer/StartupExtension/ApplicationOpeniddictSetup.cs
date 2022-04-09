using DLL.Context;
using Microsoft.Extensions.DependencyInjection;

namespace APIAuthServer.StartupExtension
{
    public static class ApplicationOpeniddictSetup
    {
        public static IServiceCollection AddApplicationOpeniddict(this IServiceCollection services)
        {
            services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                    options.UseEntityFrameworkCore()
                        .UseDbContext<ApplicationDbContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the token endpoint.
                    options.SetTokenEndpointUris("/connect/token");
                    options.SetIntrospectionEndpointUris("/connect/introspect");

                    // Enable the password flow.
                    options.AllowPasswordFlow().AllowRefreshTokenFlow().AllowClientCredentialsFlow();
                        //.AllowAuthorizationCodeFlow();

                    // // Accept anonymous clients (i.e clients that don't send a client_id).
                    // options.AcceptAnonymousClients();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                        .AddDevelopmentSigningCertificate();

                    // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                    options.UseAspNetCore()
                        .EnableTokenEndpointPassthrough();
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });
            return services;
        }
    }
}