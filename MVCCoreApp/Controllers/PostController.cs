using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class PostController : Controller
    {
        public IActionResult PostByID(int id)
        {
            return View();
        }

        public IActionResult PostByPostName(string id)
        {
            return View();
        }
    }
}
