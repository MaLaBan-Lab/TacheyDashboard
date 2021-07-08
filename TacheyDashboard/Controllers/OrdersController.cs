using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TacheyDashboard.Controllers
{
    public class OrdersController : Controller
    {
        public OrdersController()
        {
        }
        public IActionResult Point()
        {
            return View();
        }

        public IActionResult Invite()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }
    }
}
