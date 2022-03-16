using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Repositories;

namespace CreamyCreations.Controllers
{
    public class PaymentController : Controller
    {
        private PaymentRepo paymentRepo;
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
            paymentRepo = new PaymentRepo(context);
        }

        // assume that the wedding cake id is passed in.
        public IActionResult Index(int? id = 1)
        {
            // Only send the request if we actually do have and id
            //Assume that the user may go back to the payment page without going
            // through the creation page. Redirect if the id is not set
            if (id != null)
            {
               var thing =  paymentRepo.GetCakeDetails(id.Value);
               return View(thing);

            }
            // redirect the user if the user directly requested the payment page
            Response.Redirect("/");
            return new EmptyResult();
        }
    }
}
