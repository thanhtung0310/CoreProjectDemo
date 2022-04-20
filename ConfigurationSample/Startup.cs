using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationSample
{
    public class Startup
    {
        // dependency injection
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // gọi ra thuộc tính Message từ Configuration
                    await context.Response.WriteAsync(Configuration.GetSection("Message").Value + "\n");
                    // gọi ra thuộc tính ConnectionStrings:SqlServerConnectionString từ Configuration/User Secret
                    await context.Response.WriteAsync(Configuration.GetSection("ConnectionStrings:SqlServerConnectionString").Value + "\n");
                    // gọi ra thuộc tính Arg1 từ Command line
                    await context.Response.WriteAsync(Configuration.GetSection("Arg1").Value + "\n");
                    // gọi ra thuộc tính PATH từ Environment Variables
                    await context.Response.WriteAsync(Configuration.GetSection("PATH").Value + "\n");
                });
            });
        }
    }
}
