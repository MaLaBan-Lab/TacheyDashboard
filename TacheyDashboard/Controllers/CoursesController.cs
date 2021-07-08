using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Controllers
{
    public class CoursesController : Controller
    {
        public CoursesController()
        {
        }
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Application()
        {
            return View();
        }
    }
}
