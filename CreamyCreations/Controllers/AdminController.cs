using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.Repositories;
using CreamyCreations.ViewModels;
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

        public IActionResult Details(int orderID, int userID, int weddingCakeID)
        {
            AdminOrdersRepo adminOrders = new AdminOrdersRepo(_context);
            var details = adminOrders.getDetails(orderID, userID, weddingCakeID);
            return View(details);
        }
        public IActionResult Edit(int weddingCakeID)
        {
            AdminOrdersRepo adminRepo = new AdminOrdersRepo(_context);
            var details = adminRepo.getEditDetails(weddingCakeID);
            ViewBag.Fillings = _context.Fillings;
            ViewBag.Levels = _context.Levels;
            ViewBag.Labels = _context.Labels;
            ViewBag.Covers = _context.Covers;
            return View(details);
        }

        [HttpPost]
        public IActionResult Edit(List<DecorationCheckBoxVM> decorationsList, WeddingCakeVM weddingCakeVM)
        {
            AdminOrdersRepo adminRepo = new AdminOrdersRepo(_context);
            adminRepo.Edit(decorationsList, weddingCakeVM);
            return RedirectToAction("Orders", "Admin");
        }
    }
}
