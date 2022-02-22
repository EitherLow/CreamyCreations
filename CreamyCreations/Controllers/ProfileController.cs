using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;

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
    }
}
