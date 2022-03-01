using CreamyCreations.Data;
using CreamyCreations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Repositories
{
    public class AdminOrdersRepo
    {
        ApplicationDbContext _context;

        public AdminOrdersRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        // Get all customer orders in the database (viewable to only the admin)
        public IEnumerable<AdminOrdersVM> All()
        {
            var adminOrders = from wc in _context.WeddingCakes
                        from o in _context.Orders
                        where o.WeddingCakeId == wc.WeddingCakeId
                        select(new AdminOrdersVM()
                        {
                            orderID = o.OrderId,
                            weddingCakeID = o.WeddingCakeId,
                            userID = o.UserId,
                            deliveryDate = o.DeliveryDate.ToString("dd/MM/yyyy"),
                            price = "$" + wc.TotalPrice
                        });
            return adminOrders;
        }
    }
}
