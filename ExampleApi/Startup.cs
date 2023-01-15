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
                var assembly = typeof(Startup).Assembly;
                var basePath = Path.GetDirectoryName(assembly.Location);
                var fileName = assembly.GetName().Name + ".xml";
                opt.IncludeXmlComments(Path.Combine(basePath ?? "", fileName));
            });
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
