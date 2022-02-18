using CreamyCreations.Data;
using CreamyCreations.Models;
using CreamyCreations.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Repositories
{
    public class WeddingCakeRepo
    {
        ApplicationDbContext _context;
        public WeddingCakeRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public WeddingCakeVM BuildWeddingCake()
        {
            WeddingCakeVM weddingCakeVM = new WeddingCakeVM();
            
            weddingCakeVM.Covers = GetAllCovers();
            weddingCakeVM.Fillings = GetAllFillings();
            weddingCakeVM.Labels = GetAllLabels();
            weddingCakeVM.Levels = GetAllLevels();
            weddingCakeVM.Decorations = GetAllDecorations();

            return weddingCakeVM;
        }

        // Get all attributes from the Cover table and save it to List<>
        public List<Cover> GetAllCovers()
        {
            //var listCovers = _context.Covers; - THIS DID NOT WORK
            var coverList = from c in _context.Covers 
                             select (new Cover() { 
                                 CoverId = c.CoverId, 
                                 Flavor = c.Flavor, 
                                 Price = c.Price 
                             });
            return coverList.ToList();
        }

        // Get all attributes from the Filling table and save it to List<>
        public List<Filling> GetAllFillings()
        {
            var fillingList = from f in _context.Fillings
                            select (new Filling()
                            {
                                FillingId = f.FillingId,
                                Flavor = f.Flavor,
                                Price = f.Price
                            });
            return fillingList.ToList();
        }

        // Get all attributes from the Labels table and save it to List<>
        public List<Label> GetAllLabels()
        {
            var labelList = from l in _context.Labels
                              select (new Label()
                              {
                                  LabelId = l.LabelId,
                                  LabelName = l.LabelName,
                                  Price = l.Price
                              });
            return labelList.ToList();
        }

        // Get all attributes from the Levels table and save it to List<>
        public List<Level> GetAllLevels()
        {
            var levelList = from l in _context.Levels
                            select (new Level()
                            {
                                LevelNumber = l.LevelNumber,
                                Price = l.Price
                            });
            return levelList.ToList();
        }

        // Get all attributes from the Decorations table and save it to List<>
        public List<Decoration> GetAllDecorations()
        {
            var decorationList = from d in _context.Decorations
                            select (new Decoration()
                            {
                                DecorationId = d.DecorationId,
                                Decoration1 = d.Decoration1,
                                Price = d.Price
                            });
            return decorationList.ToList();
        }
    }
}
