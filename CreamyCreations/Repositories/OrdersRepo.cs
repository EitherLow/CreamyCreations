using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.ViewModels;

namespace CreamyCreations.Repositories
{
    public class OrdersRepo
    {
        private ApplicationDbContext _context;
        public OrdersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrdersVm> GetAllOrders(int id)
        {
            var test = from o in _context.Orders
                from w in _context.WeddingCakes
                where o.UserId == 2
                where o.WeddingCakeId == w.WeddingCakeId
                select (new OrdersVm()
                {
                    OrderId = o.OrderId,
                    price = "$" + w.TotalPrice,
                    Date = o.DeliveryDate.ToString("dd/MM/yyyy")

                });
            return test;

        }


    }
}
