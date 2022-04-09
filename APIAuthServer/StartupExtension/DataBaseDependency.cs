using System;
using DLL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace APIAuthServer.StartupExtension
{
    public static class DataBaseDependency
    {
        public static IServiceCollection AddDatabaseDependency(this IServiceCollection services,IConfiguration configuration)
        {
            // // Replace with your connection string.
            // var connectionString = "server=localhost;user=root;password=1234;database=ef";

            // Replace with your server version and type.
            // Use 'MariaDbServerVersion' for MariaDB.
            // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
            // For common usages, see pull request #1233.
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            // Replace 'YourDbContext' with the name of your own DbContext derived class.
            services.AddDbContext<ApplicationDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion)
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    .UseOpenIddict()
            );
            
           
            return services;
        }
    }
}