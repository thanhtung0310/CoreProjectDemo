using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestPipelineDemo.Middlewares
{
    public class SimpleMiddleware
    {
        private readonly RequestDelegate _next;
        public SimpleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<div> Hello World from the Simple Middleware! </div>");
            // gọi ra middleware tiếp theo thông qua next
            await _next(context);
            await context.Response.WriteAsync("<div> Bye from the Simple Middleware! </div>");
        }
    }
}
