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

        public CreateWeddingCakeVM BuildWeddingCake()
        {
            CreateWeddingCakeVM weddingCakeVM = new CreateWeddingCakeVM();
            
            weddingCakeVM.Covers = GetAllCovers();
            weddingCakeVM.Fillings = GetAllFillings();
            weddingCakeVM.Labels = GetAllLabels();
            weddingCakeVM.Levels = GetAllLevels();
            weddingCakeVM.DecorationCheckBoxes = GetDecorationCheckBoxes();

            return weddingCakeVM;
        }


        /*************************************************
        * INITIALIZE A WEDDING CAKE VM
        ************************************************/

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

        // Get all attributes from the DecorationCheckBoxesVM and save it to List<>
        public List<DecorationCheckBoxVM> GetDecorationCheckBoxes()
        {
            var decorationList = from d in _context.Decorations
                                 select (new DecorationCheckBoxVM()
                                 {
                                     DecorationId = d.DecorationId,
                                     Price = d.Price,
                                     DecorationTitle = d.Decoration1,
                                     IsChecked = false
                                 });

            return decorationList.ToList();
        }

        /*************************************************
        * CALCULATE TOTAL PRICE
        ************************************************/
        public decimal GetTotalPrice()
        {
            return 19;
        }

        /*************************************************
        * CREATE NEW WEDDING CAKE
        ************************************************/
        public void CreateWeddingCake(CreateWeddingCakeVM cakeVM, WeddingCake newWeddingCake)
        {
            // Create a list of the many-to-many bridge wedding cake decoration table
            List<WeddingCakeDecoration> newWeddingCakeDecorationList = new List<WeddingCakeDecoration>();


            // Calculate Total Price
            // Create huge select to the DB and get prices of all
            var getCover = _context.Covers.Where(c => c.CoverId == cakeVM.CoverId).Select(p => p.Price).FirstOrDefault();
            //decimal totalPrice = coverPrice + 2;

            // Create a new wedding cake
            newWeddingCake.CoverId = cakeVM.CoverId;
            newWeddingCake.FillingId = cakeVM.FillingId;
            newWeddingCake.LabelId = cakeVM.LabelId;
            newWeddingCake.LevelNumber = cakeVM.LevelId;
            newWeddingCake.TotalPrice = cakeVM.TotalPrice;
            _context.WeddingCakes.Add(newWeddingCake);
            _context.SaveChanges();

            // Get the auto-generated wedding cake ID 
            int newWeddingCakeId = newWeddingCake.WeddingCakeId;

            // Find Decoration that has been checked by the user and save it to the List
            foreach (var singleDecoration in cakeVM.DecorationCheckBoxes)
            {
                if (singleDecoration.IsChecked == true)
                {
                    newWeddingCakeDecorationList.Add(new WeddingCakeDecoration() { WeddingCakeId = newWeddingCakeId, DecorationId = singleDecoration.DecorationId });
                }
            }

            // Go through each WeddingCakeDecoration and save it to the database
            foreach (var singleWeddingCakeDecoration in newWeddingCakeDecorationList)
            {
                _context.WeddingCakeDecorations.Add(singleWeddingCakeDecoration);
            }

            // Save all changes
            _context.SaveChanges();
        }
    }
}
