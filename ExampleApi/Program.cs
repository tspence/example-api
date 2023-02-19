using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ExampleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startup = new Startup();
            var builder = WebApplication.CreateBuilder(args);
            startup.ConfigureServices(builder.Services);
            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Note that Swagger should ALWAYS be present on every environment.
            // Do NOT hide swagger on non-development environments.
            app.UseSwagger(opt =>
            {
            });
            app.UseSwaggerUI(options =>
            {
            });

            app.UseHttpsRedirection();
            app.MapControllers();
            app.MapRazorPages();
            app.Run();
        }
    }
}