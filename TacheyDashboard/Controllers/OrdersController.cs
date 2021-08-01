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
using Tachey001.Repository;

namespace TacheyDashboard.Controllers
{
   
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly OrderInterface _ordersService;
        private readonly TacheyContext _context;


        public OrdersController(OrderInterface orderservice,TacheyContext context)
        {
            _context = context;
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
            List<TicketViewModel> returnData = new List<TicketViewModel>();
           
            foreach (var item in result)
            {

                returnData.Add(new TicketViewModel
                {
                    TicketId = item.TicketId,
                    TicketName = item.TicketName,
                    TicketStatus = item.TicketStatus,
                    Discount = item.Discount,
                    Ticketdate = item.Ticketdate.ToString().Remove(10),
                    PayMethod = item.PayMethod,
                    ProductType = item.ProductType,
                    UseTime = item.UseTime,
                    Send = item.Send
                });
            }
                string jsonString = JsonConvert.SerializeObject(returnData);
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
        [HttpGet]
        public dynamic TicketData()
        {
            List<TicketViewModel> returnData = new List<TicketViewModel>();
            var result = _ordersService.GetTicket();
            foreach (var item in result)
            {
               
                returnData.Add(new TicketViewModel {
                    TicketId = item.TicketId,
                    TicketName = item.TicketName,
                    TicketStatus = item.TicketStatus,
                    Discount=item.Discount,
                    Ticketdate = item.Ticketdate.ToString().Remove(10),
                    PayMethod=item.PayMethod,
                    ProductType=item.ProductType,
                    UseTime=item.UseTime,
                    Send=item.Send
            });
               
            }
            string jsonString = JsonConvert.SerializeObject(returnData);
            return jsonString;
        }
        [HttpPost]
        public void SendInvite(string ticketid)
        {
            _ordersService.SendTicket(ticketid);
        }

        [HttpPost]
        public  IActionResult Create([FromBody] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("Invite");
            }

            return View(ticket);
        }

    }
}