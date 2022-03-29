using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Repositories
{
    public class AdminCustomizationRepo
    {
        ApplicationDbContext _context;
        public AdminCustomizationRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Cover> getCovers()
        {
            var covers = from c in _context.Covers
                     select new Cover
                     {
                         Price = c.Price,
                         CoverId = c.CoverId,
                         Flavor = c.Flavor
                     };
            return covers;
        }

        public bool EditCovers(IEnumerable<Cover> covers)
        {
            foreach (Cover cover in covers)
            {
                var cov = (from c in _context.Covers
                           where c.CoverId == cover.CoverId
                           select c).FirstOrDefault();
                cov.Price = cover.Price;
                cov.Flavor = cover.Flavor;
                _context.Entry(cov).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return true;
        }
    }
}
