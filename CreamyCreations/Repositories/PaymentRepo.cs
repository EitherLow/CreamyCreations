using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CreamyCreations.Repositories
{
    public class PaymentRepo
    {
        ApplicationDbContext _context;

        public PaymentRepo(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public PaymentVM GetCakeDetails(int weddingCakeId)
        {
            var paymentSummary = new PaymentVM();
            
            
            paymentSummary.WeddingCakeId = weddingCakeId;
            paymentSummary.Fillings = GetAllFillings(weddingCakeId);
            paymentSummary.Covers = GetAllCovers(weddingCakeId);
            paymentSummary.Decorations = GetAllDecorations(weddingCakeId);
            paymentSummary.TotalPrice = GetTotalPrice(weddingCakeId);
            return paymentSummary;
        }

        private WeddingCake GetWeddingCake(int weddingCakeId)
        {
            //var weddingCake = _context.WeddingCakes.FirstOrDefault(wc => wc.WeddingCakeId == weddingCakeId);
            var weddingCake2 =
                (from wc in _context.WeddingCakes
                    where wc.WeddingCakeId == weddingCakeId
                    select (new WeddingCake()
                    {
                        WeddingCakeId = wc.WeddingCakeId,
                        CoverId = wc.CoverId,
                        FillingId = wc.FillingId,
                        LabelId = wc.LabelId,
                        LevelNumber = wc.LevelNumber,
                        TotalPrice = wc.TotalPrice,
                    })).FirstOrDefault();
            return weddingCake2;
        }

        private List<Filling> GetAllFillings(int weddingCakeId)
        {
            //var weddingCake = GetWeddingCake(weddingCakeId);
            //var fillings = _context.Fillings.Where(f => Equals(f.WeddingCakes, weddingCake)).ToList();

            var fillings2 = (from f in _context.Fillings
                from wc in _context.WeddingCakes
                where wc.WeddingCakeId == weddingCakeId
                where f.FillingId == wc.FillingId
                select (new Filling()
                {
                    FillingId = f.FillingId,
                    Price = f.Price,
                    Flavor = f.Flavor
                })).ToList();
            return fillings2;
        }

        private List<Cover> GetAllCovers(int weddingCakeId)
        {
            //var weddingCake = GetWeddingCake(weddingCakeId);
            //var covers = _context.Covers.Where(c => Equals(c.WeddingCakes, weddingCake)).ToList();

            var covers2 = (from c in _context.Covers
                from wc in _context.WeddingCakes
                where wc.WeddingCakeId == weddingCakeId
                where c.CoverId == wc.CoverId
                select (new Cover()
                {
                    CoverId = c.CoverId,
                    Price = c.Price,
                    Flavor = c.Flavor
                })).ToList();
            return covers2;
        }

        private List<Decoration> GetAllDecorations(int weddingCakeId)
        {
            //var weddingCake = GetWeddingCake(weddingCakeId);
            //var decorations = _context.Decorations.Where(d => Equals(d.WeddingCakeDecorations, weddingCake)).ToList();

            var decorations2 = (from d in _context.Decorations
                from dd in  _context.WeddingCakeDecorations
                from wc in _context.WeddingCakes
                where wc.WeddingCakeId == weddingCakeId
                where dd.WeddingCakeId == wc.WeddingCakeId
                where d.DecorationId == dd.DecorationId
                select (new Decoration()
                {
                    DecorationId = d.DecorationId,
                    Price = d.Price,
                    Decoration1 = d.Decoration1
                })).ToList();
            return decorations2;
        }

        private decimal GetTotalPrice(int weddingCakeId)
        {
            var weddingCake = GetWeddingCake(weddingCakeId);
            return weddingCake.TotalPrice;
        }
    }
}
