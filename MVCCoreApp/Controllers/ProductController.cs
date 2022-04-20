using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class ProductController : Controller
    {
        //GET: product
        public IActionResult Index()
        {
            return View();
        }

        //GET: product/id
        [HttpGet]
        public string Edit(string id)
        {
            return "Hello from edit method";
        }

        //POST: product/model
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return new List<ProductModel>();
        }

        //GET: product/test
        [HttpGet("{id}")]
        public List<ProductModel> GetByID(string id)
        {
            return new List<ProductModel>();
        }

        //POST: product
        [HttpPost]
        public IActionResult Create(ProductModel model)
        {
            // create a product in DB
            return Ok();
        }

        //PUT: product/10
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] ProductModel model)
        {
            // create a product in DB
            return Ok();
        }

        //DELETE: product/10
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            // delete a product in DB
            return Ok();
        }
    }
}
