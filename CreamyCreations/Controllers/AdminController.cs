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

        // customization 
        [Authorize]
        public IActionResult Customization()
        {
            return View();
        }

        public IActionResult AddCover()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCover(Cover cover)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.AddCover(cover);
            return RedirectToAction("Customization", "Admin");
        }
        public IActionResult EditCovers()
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            var covers = repo.getCovers();
            return View(covers);
        }

        [HttpPost]
        public IActionResult EditCovers(CoversVM coversVM)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.EditCovers(coversVM);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult AddFilling()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilling(Filling filling)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.AddFilling(filling);
            return RedirectToAction("Customization", "Admin");
        }
        public IActionResult EditFillings()
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            var fillings = repo.getFillings();
            return View(fillings);
        }

        [HttpPost]
        public IActionResult EditFillings(FillingsVM fillingsVM)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.EditFillings(fillingsVM);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult AddLabel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLabel(Label label)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.AddLabel(label);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult EditLabels()
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            var labels = repo.getLabels();
            return View(labels);
        }

        [HttpPost]
        public IActionResult EditLabels(LabelsVM labelsVM)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.EditLabels(labelsVM);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult AddLevel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddLevel(Level level)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.AddLevel(level);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult EditLevels()
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            var levels = repo.getLevels();
            return View(levels);
        }

        [HttpPost]
        public IActionResult EditLevels(LevelsVM levelsVM)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.EditLevels(levelsVM);
            return RedirectToAction("Customization", "Admin");
        }

        public IActionResult AddDecoration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDecoration(Decoration decoration)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.AddDecoration(decoration);
            return RedirectToAction("Customization", "Admin");
        }
        public IActionResult EditDecorations()
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            var decorations = repo.getDecorations();
            return View(decorations);
        }

        [HttpPost]
        public IActionResult EditDecorations(DecorationsVM decorationsVM)
        {
            AdminCustomizationRepo repo = new AdminCustomizationRepo(_context);
            repo.EditDecorations(decorationsVM);
            return RedirectToAction("Customization", "Admin");
        }
        // orders 
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
        public IActionResult Edit(WeddingCakeVM cake, WeddingCakeVM weddingCakeVM)
        {
            AdminOrdersRepo adminRepo = new AdminOrdersRepo(_context);
            adminRepo.Edit(cake.DecorationCheckBoxes, weddingCakeVM);
            return RedirectToAction("Orders", "Admin");
        }
    }
}
