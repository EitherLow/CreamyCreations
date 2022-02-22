using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.Repositories;

namespace CreamyCreations.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.Name != null)
            {
                string getUserName = User.Identity.Name;
                Console.WriteLine("Console Write: Profile Controller line 23 -> {0}",getUserName);
                // longer way
                /*var userData = _context.Users.Where(user => user.Email == getUserName).FirstOrDefault();*/
                var userData = _context.Users.FirstOrDefault(user => user.Email == getUserName);
                return View(userData);
            }

            // TODO: Please fix this so the page does not crash???
            Response.Redirect("/");

            return new EmptyResult();
        }

        public IActionResult Edit()
        {
            if (User.Identity != null && User.Identity.Name != null)
            {
                string getUserName = User.Identity.Name;
                var userData = _context.Users.FirstOrDefault(user => user.Email == getUserName);
                return View(userData);
            }
            
            Response.Redirect("/");
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(int id,User user)
        {
            Console.WriteLine("ProfileController: Line 54 -> {0}",id);
            if (ModelState.IsValid)
            {
                var repo = new ProfileRepo(_context);
                var userEmail = User.Identity.Name;
                var status = repo.UpdateProfile(user, id);
                if (!status)
                {
                    ViewBag.Error = "Something went wrong. Try again later";
                }
                // goto the profile page if we the account update is successful
                ViewBag.statusMessage = "Successfully Updated your profile";
                return View("Index", user);
            }

            ViewBag.statusMessage = "Something went wrong!";
            return View();
        }
    }
}
