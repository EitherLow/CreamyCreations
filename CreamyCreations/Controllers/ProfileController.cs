using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.Repositories;
using CreamyCreations.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CreamyCreations.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ProfileController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                var vm = new UserProfileVM()
                    {Email = userData.Email, FirstName = userData.FirstName, LastName = userData.LastName, UserId = userData.UserId};
                return View(vm);
            }

            // TODO: Please fix this so the page does not crash???
            Response.Redirect("/");

            return new EmptyResult();
        }

        public IActionResult Edit()
        {
            if (User.Identity != null && User.Identity.Name != null)
            {
                var userRepo = new UserRepo(_context);
                var userId = userRepo.GetId(User.Identity.Name);
                ViewBag.userId = userId;
                string getUserName = User.Identity.Name;
                var userData = _context.Users.FirstOrDefault(user => user.Email == getUserName);
                return View(userData);
            }
            
            Response.Redirect("/");
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult Edit(UserProfileVM user)
        {
            Console.WriteLine("ProfileController: Line 54 -> {0}",user.UserId);
            if (ModelState.IsValid)
            {
                var repo = new ProfileRepo(_context);
                var status = repo.UpdateProfile(user);
                if (!status)
                {
                    ViewBag.Error = "Something went wrong. Try again later";
                }
                // goto the profile page if we the account update is successful
                ViewBag.statusMessage = "Successfully Updated your profile";
                return View("Index", user);
            }

            ViewBag.statusMessage = "Something went wrong!";
            return View("Index", user);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                // ChangePasswordAsync changes the user password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                // Upon successfully changing the password refresh sign-in cookie
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index", "Profile");
            }

            return View(model);
        }
    }
}
