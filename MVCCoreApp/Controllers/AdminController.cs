using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class AdminController : Controller
    {
        public string Index()
        {
            return "This is Index view of Admin";
        }
    }
}
