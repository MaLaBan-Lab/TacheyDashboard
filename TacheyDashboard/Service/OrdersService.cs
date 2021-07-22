using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Interface;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel;

namespace TacheyDashboard.Service
{
    public class OrdersService : OrderInterface
    {

        private readonly TacheyContext _context;
        public OrdersService(TacheyContext context)
        {
            _context = context;
        }
           
       
        public List<OrderViewModel> GetOrderViewModels()
        {
            var order = _context.Orders;

            var result = (from o in order
                         select new OrderViewModel
                         {
                             OrderId = o.OrderId,
                             MemberId = o.MemberId,
                             PayMethod = o.PayMethod,
                             OrderDate = o.OrderDate,
                             OrderStatus = o.OrderStatus,
                             //TotalPrice = GetTotalPrice(o.OrderId)
                         }).ToList();
            foreach (var item in result)
            {
                item.TotalPrice = GetTotalPrice(item.OrderId);
            }
            return result.ToList();
        }
        //傳OrderID進來比對資料

        public decimal GetTotalPrice(string OrderId)
        {
            var orderdetail = _context.OrderDetails;
            decimal result = 0;
            foreach (var item in orderdetail)
            {
                if (item.OrderId == OrderId)
                {
                    result = (decimal)(result + item.UnitPrice);
                }
            }
            return result;
        }

        public List<Point> GetPoint()
        {
            var point = _context.Points;

            var result = from p in point
                         select p;
        
            return result.ToList();
        }
        public List<Ticket> GetTicket()
        {
            var ticket = _context.Tickets;

            var result = from t in ticket
                         select t;

            return result.ToList();
        }


    }
}