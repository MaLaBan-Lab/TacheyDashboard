using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;
using TacheyDashboard.Service;

namespace TacheyDashboard.Controllers
{
    public class MembersController : Controller
    {
        public MembersController()
        {
        }

        public IActionResult Member()
        {
            return View();
        }
    }
}
