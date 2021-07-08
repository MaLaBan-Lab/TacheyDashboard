﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly TacheyContext _context;

        public MembersController(TacheyContext context)
        {
            _context = context;
        }

        public IActionResult Member()
        {
            return View(_context.AspNetUsers);
        }
    }
}