using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.ViewModels;

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

            var fillings = GetAllFillings(weddingCakeId);
            var covers = GetAllCovers(weddingCakeId);
            var decorations = GetAllDecorations(weddingCakeId);
            paymentSummary.WeddingCakeId = weddingCakeId;
            paymentSummary.Fillings = fillings;
            paymentSummary.Covers = covers;
            paymentSummary.Decorations = decorations;
            return paymentSummary;
        }

        private WeddingCake GetWeddingCake(int weddingCakeId)
        {
            var weddingCake = _context.WeddingCakes.FirstOrDefault(wc => wc.WeddingCakeId == weddingCakeId);
            return weddingCake;
        }

        private List<Filling> GetAllFillings(int weddingCakeId)
        {
            var weddingCake = GetWeddingCake(weddingCakeId);
            var fillings = _context.Fillings.Where(f => Equals(f.WeddingCakes, weddingCake)).ToList();
            return fillings;
        }

        private List<Cover> GetAllCovers(int weddingCakeId)
        {
            var weddingCake = GetWeddingCake(weddingCakeId);
            var covers = _context.Covers.Where(c => Equals(c.WeddingCakes, weddingCake)).ToList();
            return covers;
        }

        private List<Decoration> GetAllDecorations(int weddingCakeId)
        {
            var weddingCake = GetWeddingCake(weddingCakeId);
            var decorations = _context.Decorations.Where(d => Equals(d.WeddingCakeDecorations, weddingCake)).ToList();
            return decorations;
        }
    }
}
