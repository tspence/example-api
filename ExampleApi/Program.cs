using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace ExampleApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Note that Swagger should ALWAYS be present on every environment.
            // Do NOT hide swagger on non-development environments.
            app.UseSwagger(opt =>
            {
            });
            app.UseSwaggerUI(options =>
            {
                //options.OAuthAppName("Swagger Client");
                //options.OAuthClientId(clientId);
                //options.OAuthClientSecret(clientSecret);
                //options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });

            app.UseHttpsRedirection();
            app.MapControllers();
            app.Run();
        }
    }
}