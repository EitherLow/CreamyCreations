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
            var adminOrders = _context.Orders.Select(u => new AdminOrdersVM()
            {
                orderID = u.OrderId,
                weddingCakeID = u.WeddingCakeId,
                userID = u.UserId,
                addressID = u.AddressId,
                deliveryDate = u.DeliveryDate

            });
            return adminOrders;
        }
    }
}
