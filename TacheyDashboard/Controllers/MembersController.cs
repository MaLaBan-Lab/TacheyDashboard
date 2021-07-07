using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Member()
        {
            return View();
        }
    }
}
