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

        // Get all customer orders in the database 
        public IEnumerable<AdminOrdersVM> All()
        {
            var adminOrders = 
                        from wc in _context.WeddingCakes
                        from u in _context.Users
                        from o in _context.Orders
                        where o.WeddingCakeId == wc.WeddingCakeId
                        where o.UserId == u.UserId
                        select(new AdminOrdersVM()
                        {
                            orderID = o.OrderId,
                            weddingCakeID = o.WeddingCakeId,
                            userID = o.UserId,
                            deliveryDate = o.DeliveryDate.ToString("dd/MM/yyyy"),
                            email = u.Email,
                            price = "$" + wc.TotalPrice

                        });
            return adminOrders;
        }

        public CustomerWeddingCakeVM getDetails(int orderID, int userID, int weddingCakeID)
        {
            var weddingCake = (from wc in _context.WeddingCakes
                              where wc.WeddingCakeId == weddingCakeID
                              select wc).FirstOrDefault();

            var user = (from u in _context.Users
                       where u.UserId == userID
                       select u).FirstOrDefault();

            var order = (from o in _context.Orders
                        where o.OrderId == orderID
                        select o).FirstOrDefault();

            var query =  (from f in _context.Fillings
                         from la in _context.Labels
                         from le in _context.Levels
                         from c in _context.Covers
                         from d in _context.Decorations
                         from wcd in _context.WeddingCakeDecorations
                         where weddingCake.LabelId == la.LabelId
                         where weddingCake.CoverId == c.CoverId
                         where weddingCake.FillingId == f.FillingId
                         where weddingCake.LevelNumber == le.LevelNumber
                         where weddingCake.WeddingCakeId == wcd.DecorationId
                         where d.DecorationId == wcd.DecorationId
                         select (new CustomerWeddingCakeVM()
                         {
                             orderID = order.OrderId,
                             userID = user.UserId,
                             firstName = user.FirstName,
                             lastName = user.LastName,
                             weddingCakeID = weddingCake.WeddingCakeId,
                             level = le.LevelNumber,
                             cover = c.Flavor,
                             filling = f.Flavor,
                             label = la.LabelName,
                             decoration = d.Decoration1,
                             deliveryDate = order.DeliveryDate.ToString("dd/MM/yyyy"),
                             price = "$" + weddingCake.TotalPrice,
                         })).FirstOrDefault();
            return query;
        }

        public bool Edit(CustomerWeddingCakeVM cwc)
        {
            var cakeId = (from o in _context.Orders
                       where o.OrderId == cwc.orderID
                       select o.WeddingCakeId).FirstOrDefault();

            var cake = (from wc in _context.WeddingCakes
                        where wc.WeddingCakeId == cakeId
                        select wc).FirstOrDefault();

            var level = (from le in _context.Levels
                        where le.LevelNumber == cake.LevelNumber
                        select le).FirstOrDefault();

            var cover = (from c in _context.Covers
                         where c.CoverId == cake.CoverId
                         select c).FirstOrDefault();

            var label = (from l in _context.Labels
                         where l.LabelId == cake.LabelId
                         select l).FirstOrDefault();

            var filling = (from f in _context.Fillings
                         where f.FillingId == cake.FillingId
                         select f).FirstOrDefault();

            var decorationID = (from wd in _context.WeddingCakeDecorations
                                where wd.WeddingCakeId == cakeId
                                select wd.DecorationId).FirstOrDefault();

            var decoration = (from d in _context.Decorations
                         where d.DecorationId == decorationID
                         select d).FirstOrDefault();

            level.LevelNumber = cwc.level;
            _context.SaveChanges();
            cover.Flavor = cwc.cover;
            _context.SaveChanges();
            label.LabelName = cwc.label;
            _context.SaveChanges();
            filling.Flavor = cwc.filling;
            _context.SaveChanges();
            decoration.Decoration1 = cwc.decoration;
            _context.SaveChanges();

            return true;
        }

    }
}
