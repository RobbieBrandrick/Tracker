using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;
using ServiceProvider = Tracker.Core.Services.Infrastructure.ServiceProvider;

namespace Tracker.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "frontend/dist"; });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Tracker.Web", Version = "v1"});
            });
            
            foreach (ServiceDescriptor descriptor in ServiceProvider.GetServiceCollection(Configuration))
            {
                services.Add(descriptor);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tracker.Web v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                
                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "frontend" },
                    npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
                    regex: "Compiled successfully",
                    forceKill: true,
                    wsl: false, // Set to true if you are using WSL on windows. For other operating systems it will be ignored
                    runner: ScriptRunnerType.Yarn
                );
                
            });

            app.UseSpa(builder => { builder.Options.SourcePath = "frontend"; });
        }
    }
}