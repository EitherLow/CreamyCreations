using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Repositories;

namespace CreamyCreations.Controllers
{
    public class OrdersController : Controller
    {
        private ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var user = (from u in _context.Users
                where u.UserId == 1
                select u).FirstOrDefault();

            ViewBag.firstName = user?.FirstName;
            ViewBag.lastName = user?.LastName;
                var ordersRepo = new OrdersRepo(_context);
            var orders = ordersRepo.GetAllOrders(id);

            return View(orders);
        }
    }
}
