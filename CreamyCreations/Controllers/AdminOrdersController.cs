using CreamyCreations.Data;
using CreamyCreations.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Controllers
{
    public class AdminOrdersController : Controller
    {
        private readonly ILogger<AdminOrdersController> _logger;
        private readonly ApplicationDbContext _context;
        public AdminOrdersController(ILogger<AdminOrdersController> logger,
                              ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            AdminOrdersRepo adminOrders = new AdminOrdersRepo(_context);
            var orders = adminOrders.All();
            return View(orders);
        }
    }
}
