using ASPNETCoreForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreForm.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            var model = new ProductEditModel();
            model.Name = "Demo";
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductEditModel model)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
                message = "Product" + model.Name + ". Rate: " + model.Rate 
                    + ". Rating: " + model.Rating + " has been created successfully!";
            else
                message = "Failed to create the product. Please try again!";
            return Content(message);
        }
    }
}
