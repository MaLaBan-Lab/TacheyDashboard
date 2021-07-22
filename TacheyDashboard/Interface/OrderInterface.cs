﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel;

namespace TacheyDashboard.Interface
{
    public interface OrderInterface
    {
        List<OrderViewModel> GetOrderViewModels();
        decimal GetTotalPrice(string OrderId);
        List<Point> GetPoint();
        List<Ticket> GetTicket();

    }
}
