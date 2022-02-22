﻿using CreamyCreations.Data;
using CreamyCreations.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;
        public AdminController(ILogger<AdminController> logger,
                              ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [Authorize]
        public IActionResult Orders()
        {
            AdminOrdersRepo adminOrders = new AdminOrdersRepo(_context);
            var orders = adminOrders.All();
            return View(orders);
        }
    }
}