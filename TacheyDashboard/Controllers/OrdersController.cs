using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using Newtonsoft.Json;

namespace TacheyDashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly TacheyContext _context;
        private readonly OrdersService _ordersService;
        public OrdersController(TacheyContext context)
        {
            _context = context;
            _ordersService = new OrdersService(context);
        }
        public IActionResult Point()
        {
            var result = _ordersService.getpointmodel();
            var jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString=jsonString;
            return View();
        }

        public IActionResult Invite()
        {
            var result = _ordersService.GetTickets();
            var jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = JsonConvert.SerializeObject(result);
            return View();
        }

        public IActionResult Order()
        {
            var result=_ordersService.GetOrderViewModels();
            var jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = JsonConvert.SerializeObject(result);
            return View();
        }
    }
}
