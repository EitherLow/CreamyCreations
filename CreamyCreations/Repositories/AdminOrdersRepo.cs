using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.ViewModels;
using Microsoft.EntityFrameworkCore;
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
                            price = "$" + wc.TotalPrice.ToString("0.00")

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

            var decorations = (from wcd in _context.WeddingCakeDecorations
                                 from d in _context.Decorations
                                 where wcd.WeddingCakeId == weddingCakeID
                                 where wcd.DecorationId == d.DecorationId
                                 select new Decoration { 
                                     DecorationId = d.DecorationId,
                                     Decoration1 = d.Decoration1,
                                     Price = d.Price
                                 }).ToList();

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
                             decorations = decorations,
                             deliveryDate = order.DeliveryDate.ToString("dd/MM/yyyy"),
                             price = "$" + weddingCake.TotalPrice.ToString("0.00")
                         })).FirstOrDefault();
            return query;
        }

        public WeddingCakeVM getEditDetails(int weddingCakeId)
        {

            var query = (from w in _context.WeddingCakes
                         where w.WeddingCakeId == weddingCakeId
                         select (new WeddingCakeVM()
                         {
                             LevelNumber = w.LevelNumber,
                             FillingId = w.FillingId,
                             CoverId = w.CoverId,
                             LabelId = w.LabelId,
                             TotalPrice = Math.Round(w.TotalPrice),
                             DecorationCheckBoxes = GetDecorationCheckBoxes(weddingCakeId)
                         })).FirstOrDefault();
            return query;
        }

        public List<DecorationCheckBoxVM> GetDecorationCheckBoxes(int weddingCakeId)
        {
            var decorationIds = (from wcd in _context.WeddingCakeDecorations
                                 where wcd.WeddingCakeId == weddingCakeId
                                 select wcd.DecorationId).ToList();

            var allDecorationIds = (from d in _context.Decorations
                                    select d.DecorationId).ToList();

            List<DecorationCheckBoxVM> decorationsList = new List<DecorationCheckBoxVM>();

            
            foreach (var decorId in allDecorationIds)
            {
                if(decorationIds.Contains(decorId))
                {
                    var decorationChecked = (from d in _context.Decorations
                                             where decorId == d.DecorationId
                                             select (new DecorationCheckBoxVM()
                                             {
                                                 DecorationId = d.DecorationId,
                                                 Price = d.Price,
                                                 DecorationTitle = d.Decoration1,
                                                 IsChecked = true
                                             })).FirstOrDefault();
                    decorationsList.Add(decorationChecked);
                }
                else
                {
                    var decorationUnchecked = (from d in _context.Decorations
                                             where decorId == d.DecorationId
                                             select (new DecorationCheckBoxVM()
                                             {
                                                 DecorationId = d.DecorationId,
                                                 Price = d.Price,
                                                 DecorationTitle = d.Decoration1,
                                                 IsChecked = false
                                             })).FirstOrDefault();
                    decorationsList.Add(decorationUnchecked);
                }
            }

            return decorationsList;
        }

        public bool Edit(List<DecorationCheckBoxVM> decorationsList, WeddingCakeVM weddingCake)
        {
            var query = (from wc in _context.WeddingCakes
                         where wc.WeddingCakeId == weddingCake.WeddingCakeId
                         select wc).FirstOrDefault();

            query.CoverId = weddingCake.CoverId;
            _context.SaveChanges();
            query.FillingId = weddingCake.FillingId;
            _context.SaveChanges();
            query.LabelId = weddingCake.LabelId;
            _context.SaveChanges();
            query.LevelNumber = weddingCake.LevelNumber;
            query.TotalPrice = weddingCake.TotalPrice;
            _context.Entry(query).State = EntityState.Modified;
            _context.SaveChanges();

            // Create a list of the many-to-many bridge wedding cake decoration table
            List<WeddingCakeDecoration> newWeddingCakeDecorationList = new List<WeddingCakeDecoration>();


            // Find Decoration that has been checked by the user and save it to the List
            foreach (var singleDecoration in decorationsList)
            {
                if (singleDecoration.IsChecked == true)
                {
                    newWeddingCakeDecorationList.Add(new WeddingCakeDecoration() { WeddingCakeId = query.WeddingCakeId, DecorationId = singleDecoration.DecorationId });
                }
            }

            var cakes = _context.WeddingCakeDecorations.Where(c => c.WeddingCakeId == query.WeddingCakeId);
            foreach (var cake in cakes)
            {
                _context.WeddingCakeDecorations.Remove(cake);
            }
            _context.SaveChanges();

            // Go through each WeddingCakeDecoration and save it to the database
            foreach (var singleWeddingCakeDecoration in newWeddingCakeDecorationList)
            {
                _context.WeddingCakeDecorations.Add(singleWeddingCakeDecoration);
            }

            // Save all changes
            _context.SaveChanges();

            query.TotalPrice = Math.Round(weddingCake.TotalPrice, 2);
            _context.SaveChanges();
            return true;
        }

    }
}
