﻿using ExampleApi.Filters;
using ExampleBusinessLayer;
using ExampleBusinessLayer.Models;
using Searchlight;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ExampleApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddLogging();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                // Add XML comments from main assembly
                AddXmlDocForAssembly(opt, typeof(Startup));
                AddXmlDocForAssembly(opt, typeof(BusinessLayer));
                opt.OperationFilter<SearchlightSwashbuckleFilter>();
                opt.SchemaFilter<SearchlightSwashbuckleFilter>();
            });
            var engine = new SearchlightEngine()
                .AddClass(typeof(BlogModel))
                .AddClass(typeof(PostModel));
            services.AddSingleton(engine);
        }

        private static void AddXmlDocForAssembly(SwaggerGenOptions opt, Type type)
        {
            var assembly = type.Assembly;
            var basePath = Path.GetDirectoryName(assembly.Location);
            var fileName = assembly.GetName().Name + ".xml";
            opt.IncludeXmlComments(Path.Combine(basePath ?? "", fileName));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Do NOT hide swagger on non-development environments.
            app.UseSwagger(opt => { });
            app.UseSwaggerUI(options => { });
            app.UseHttpsRedirection();
        }
    }
}
