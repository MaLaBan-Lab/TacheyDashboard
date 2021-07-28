using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using TacheyDashboard.ViewModel;
using TacheyDashboard.Interface;

using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace TacheyDashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly OrderInterface _ordersService;
      

        public OrdersController(OrderInterface orderservice)
        {
            _ordersService = orderservice;
        }
        public IActionResult Point()
        {
            var result= _ordersService.GetPoint();
            string jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = jsonString;
            return View(result);
        }

        public IActionResult Invite()
        {
            var result = _ordersService.GetTicket();
            string jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = jsonString;
            return View();
        }

        public IActionResult Order()
        {
            var result = _ordersService.GetOrderViewModels();
            string jsonString = JsonConvert.SerializeObject(result);
            ViewBag.jsonString = jsonString;
            return View();
        }

        [HttpPost]
        public dynamic OrderData()
        {
            var result = _ordersService.GetOrderViewModels();
            string jsonString = JsonConvert.SerializeObject(result);
            return jsonString;
        }
        [HttpPost]
        public void SendInvite(string ticketid)
        {
            _ordersService.SendTicket(ticketid);
        }




    }
}