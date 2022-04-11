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

        /*************************************************
        * CREATE
        ************************************************/
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            WeddingCakeRepo weddingCakeRepo = new WeddingCakeRepo(_context);
            var weddingCakeVM = weddingCakeRepo.BuildWeddingCake();
            return View(weddingCakeVM);
            
        }

        [HttpPost]
        public IActionResult Create(CreateWeddingCakeVM cakeVM, WeddingCake newWeddingCake)
        {   
            WeddingCakeRepo weddingCakeRepo = new WeddingCakeRepo(_context);
            UserRepo userRepo = new UserRepo(_context);

            // Ensure Data Model is valid.
            if (ModelState.IsValid)
            {
                weddingCakeRepo.CreateWeddingCake(cakeVM, newWeddingCake);
                ViewData["CakeID"] = newWeddingCake.WeddingCakeId;
                ViewData["UserID"] = userRepo.GetId(User.Identity.Name);

                return RedirectToAction("Index", "Payment", new { id = (Int32)ViewBag.CakeID, userId = (Int32)ViewBag.UserID});
            }
            
            return View();
        }
    }
}
