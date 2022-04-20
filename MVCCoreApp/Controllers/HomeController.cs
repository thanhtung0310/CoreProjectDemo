using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class HomeController
    {
        HttpContext ctx;
        public HomeController(IHttpContextAccessor _ctx)
        {
            ctx = _ctx.HttpContext;
        }

        public async void Index()
        {
            // set status code
            ctx.Response.StatusCode = 200;

            // set content type
            ctx.Response.ContentType = "text/html";

            // create response
            ctx.Response.Headers.Add("SomeHeader", "Value");
            byte[] content = Encoding.ASCII.GetBytes("<html><body>Hello World!</body></html>");

            // sent to client
            await ctx.Response.Body.WriteAsync(content, 0, content.Length);

        }

        //public IActionResult Index()
        //{
        //    var model = new IndexModel();
        //    model.Message = "Hello from Model";
        //    return View(model);
        //}
    }
}
