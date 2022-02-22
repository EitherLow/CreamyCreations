﻿using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.Repositories;
using CreamyCreations.ViewModels;
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

        [HttpGet]
        public IActionResult Create()
        {
            WeddingCakeRepo weddingCakeRepo = new WeddingCakeRepo(_context);
            var weddingCakeVM = weddingCakeRepo.BuildWeddingCake();
            return View(weddingCakeVM);
            
        }

        [HttpPost]
        public IActionResult Create([Bind("LevelId,LabelId,CoverId,FillingId,TotalPrice")] WeddingCake newWeddingCake)
        {
            WeddingCakeRepo weddingCakeRepo = new WeddingCakeRepo(_context);
            ViewData["Message"] = "";

            // Ensure data is valid.
            if (ModelState.IsValid)
            {
                weddingCakeRepo.CreateWeddingCake(newWeddingCake);
                ViewData["Message"] = "New wedding cake has been created";
                //ViewData["accNumber"] = newBankAccount.accountNum;
                //ViewData["clientId"] = clientRepo.GetId(User.Identity.Name);

                return RedirectToAction("Index", "Home", new { message = ViewBag.Message });
            }
            return View();
        }
    }
}
