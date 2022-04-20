﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequestPipelineDemo.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestPipelineDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // request pipeline
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // middleware 1
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World from the middleware 1!");
            //    });
            //});


            // middleware cho phép chạy tiếp theo next
            app.Use(async (context, next) =>
            {
                // inline middleware
                await context.Response.WriteAsync("<div> Hello World from the middleware 1! </div>");
                // gọi ra middleware tiếp theo thông qua next
                await next.Invoke();
                await context.Response.WriteAsync("<div> Return from the middleware 1! </div>");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("<div> Hello World from the middleware 2! </div>");
                // gọi ra middleware tiếp theo thông qua next
                await next.Invoke();
                await context.Response.WriteAsync("<div> Return from the middleware 2! </div>");
            });

            app.UseMiddleware<SimpleMiddleware>();

            // middleware ngắt: chạy đến hết middleware rồi trả về
            app.Run(handler: async (context) =>
            {
                await context.Response.WriteAsync("Hello World from the middleware 3!");
            });
        }
    }
}
