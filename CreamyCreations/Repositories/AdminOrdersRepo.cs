using CreamyCreations.Data;
using CreamyCreations.Models;
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

        public WeddingCakeVM getEditDetails(int weddingCakeId)
        {
            var query = (from w in _context.WeddingCakes
                        where w.WeddingCakeId == weddingCakeId
                        select (new WeddingCakeVM(){
                            LevelNumber = w.LevelNumber,
                            FillingId = w.FillingId,
                            CoverId = w.CoverId,
                            LabelId = w.LabelId,
                            TotalPrice = w.TotalPrice
                        })).FirstOrDefault();
            return query;
        }

        public bool Edit(WeddingCake dropdownCake, WeddingCakeVM userWeddingCake, int weddingCakeId)
        {

            var cake = (from wc in _context.WeddingCakes
                        where wc.WeddingCakeId == weddingCakeId
                        select wc);
            var levelNumber = (from c in cake
                        select c.LevelNumber).FirstOrDefault();
            levelNumber = dropdownCake.LevelNumber;
            _context.SaveChanges();
            //cake.CoverId = dropdownCake.CoverId;
            //_context.SaveChanges();
            //cake.LabelId = dropdownCake.LabelId;
            //_context.SaveChanges();
            //cake.FillingId = dropdownCake.FillingId;
            //_context.SaveChanges();
            //cake.TotalPrice = dropdownCake.TotalPrice;
            //add decoration later

            return true;
        }

    }
}
