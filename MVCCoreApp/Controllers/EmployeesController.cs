using Microsoft.AspNetCore.Mvc;
using MVCCoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class EmployeesController : Controller
    {
        //[Route("")]
        //[Route("employees/{id?}")]
        //public string GetEmployeeList(int id)
        //{            
        //    return "Employee with ID " + id;
        //}
        [Route("employees")]
        public IActionResult Index()
        {
            ViewData["Para"] = "Information about Employees....";
            ViewData["Employee"] = new EmployeeModel()
            {
                emp_id = 1,
                emp_name = "Thanh Tung",
                emp_position = "Fifth Floor",
                emp_dob = "1999/03/10",
                emp_contact_number = "0123456789"

            };
            return View();
        }

        //[ActionName("staffs")]    // tương tự
        [Route("staffs")]
        public string GetStaffList()
        {
            return "Staff";
        }
    }
}
