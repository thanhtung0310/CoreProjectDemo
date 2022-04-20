using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreApp.Controllers
{
    public class EmployeesController : Controller
    {
        [Route("")]
        [Route("employees/{id?}")]
        public string GetEmployeeList(int id)
        {
            return "Employee with ID " + id;
        }

        //[ActionName("staffs")]    // tương tự
        [Route("staffs")]
        public string GetStaffList()
        {
            return "Staff";
        }
    }
}
