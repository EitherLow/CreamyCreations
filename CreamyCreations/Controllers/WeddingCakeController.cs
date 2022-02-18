using CreamyCreations.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Controllers
{
    public class WeddingCakeController : Controller
    {
        private readonly ILogger<WeddingCakeController> _logger;
        private readonly ApplicationDbContext _context;
        public WeddingCakeController(ILogger<WeddingCakeController> logger,
                              ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
