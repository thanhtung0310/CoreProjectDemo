using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseMvcWithDefaultRoute();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            // Convention Based Routing
            app.UseMvc(routes =>
            {
                //routes.MapRoute("security", "secure", new
                //{
                //    Controller = "Admin",
                //    Action = "Index"
                //});
                //routes.MapRoute("default", "{controller=Employees}/{action=Index}/{id?:int}");
                routes.MapRoute("default", "{controller}/{action}/{id}", new
                    { controller="Home", action = "Index"}, new
                    { id = new IntRouteConstraint()});
            });

            // Attribute Based Routing
            //app.UseMvc();

            app.Run(async (content) =>
            {
                await content.Response.WriteAsync("Failed to find route");
            });
        }
    }
}
