using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Repositories;
using CreamyCreations.ViewModels;
using CreamyCreations.Models;

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
        public IActionResult Index(string id = "1", int? userId = 1)
        {
            // Only send the request if we actually do have and id
            //Assume that the user may go back to the payment page without going
            // through the creation page. Redirect if the id is not set
            if (id != null)
            {
                var thing = paymentRepo.GetCakeDetails(int.Parse(id));
                ViewBag.userId = userId;
                ViewBag.totalPrice = thing.TotalPrice;
                return View(thing);

            }
            // redirect the user if the user directly requested the payment page
            Response.Redirect("/");
            return new EmptyResult();
        }
        
        // When the payment is success
        [HttpPost]
        public IActionResult Index([FromBody] PaymentFormVM payment)
        {
            Console.Write(payment);
            
            var address = new Address()
            {
                City = payment.City,
                Province = payment.Province,
                PostalCode = payment.Postal_Code,
                Street = payment.Address,
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();
            var order = new Order()
            {
                AddressId = address.AddressId,
                WeddingCakeId = int.Parse(payment.WeddingCakeId),
                UserId = int.Parse(payment.UserId),
                DeliveryDate = DateTime.Parse(payment.DeliveryDate),
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
            // redirect the user to the PaymentSuccess page with the order id
            return RedirectToAction("PaymentSuccess", new { id = order.OrderId });
        }
        
        public IActionResult PaymentSuccess(int id)
        {
            // get the total price of the order
            var order = _context.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            // get the cake details using the order
            var cake = _context.WeddingCakes.Where(c => c.WeddingCakeId == order.WeddingCakeId).FirstOrDefault();
            var price = cake.TotalPrice;

            // get the address of the order
            var address = _context.Addresses.Where(a => a.AddressId == order.AddressId).FirstOrDefault();
            
            var paymentSuccessVM = new PaymentSuccessVM()
            {
                OrderId = id,
                Price = price,
                Address = address.Street + ", " + address.City + ", " + address.Province + ", " + address.PostalCode
            };

            // return the view with the payment vm
            return View(paymentSuccessVM);
        }
    }


}




