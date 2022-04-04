using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;


IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot(configuration);
var app = builder.Build();


app.UseOcelot();
app.Run();