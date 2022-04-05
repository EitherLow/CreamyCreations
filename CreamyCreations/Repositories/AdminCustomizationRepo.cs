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
    public class AdminCustomizationRepo
    {
        ApplicationDbContext _context;
        public AdminCustomizationRepo(ApplicationDbContext context)
        {
            this._context = context;
        }


        // cover
        public CoversVM getCovers()
        {
            CoversVM vm = new CoversVM();
            vm.Covers = (from c in _context.Covers
                     select new Cover
                     {
                         Price = c.Price,
                         CoverId = c.CoverId,
                         Flavor = c.Flavor
                     }).ToList();
            return vm;
        }

        public bool EditCovers(CoversVM coversVM)
        {
           
            foreach (Cover cover in coversVM.Covers)
            {
                var cov = (from c in _context.Covers
                           where c.CoverId == cover.CoverId
                           select c).FirstOrDefault();
                decimal previousCoverPrice = cov.Price;
                cov.Price = cover.Price;
                cov.Flavor = cover.Flavor;

                var weddingCakes = (from wc in _context.WeddingCakes
                                    where wc.CoverId == cover.CoverId
                                    select wc).ToList();

                foreach(var wc in weddingCakes)
                {
                    wc.TotalPrice = wc.TotalPrice - previousCoverPrice + cov.Price;
                }
                _context.SaveChanges();
            }
            return true;
        }

        // filling
        public FillingsVM getFillings()
        {
            FillingsVM vm = new FillingsVM();
            vm.Fillings = (from c in _context.Fillings
                           select new Filling
                         {
                             Price = c.Price,
                             FillingId = c.FillingId,
                             Flavor = c.Flavor
                         }).ToList();
            return vm;
        }

        public bool EditFillings(FillingsVM fillingsVM)
        {

            foreach (var filling in fillingsVM.Fillings)
            {
                var fil = (from c in _context.Fillings
                           where c.FillingId == filling.FillingId
                           select c).FirstOrDefault();
                decimal previousFillingPrice = fil.Price;
                fil.Price = filling.Price;
                fil.Flavor = filling.Flavor;

                var weddingCakes = (from wc in _context.WeddingCakes
                                    where wc.FillingId == filling.FillingId
                                    select wc).ToList();

                foreach (var wc in weddingCakes)
                {
                    wc.TotalPrice = wc.TotalPrice - previousFillingPrice + fil.Price;
                }
                _context.SaveChanges();
            }
            return true;
        }

        // filling
        public LabelsVM getLabels()
        {
            LabelsVM vm = new LabelsVM();
            vm.Labels = (from c in _context.Labels
                           select new Label
                           {
                               Price = c.Price,
                               LabelId = c.LabelId,
                               LabelName = c.LabelName
                           }).ToList();
            return vm;
        }

        public bool EditLabels(LabelsVM labelsVM)
        {

            foreach (var label in labelsVM.Labels)
            {
                var lab = (from c in _context.Labels
                           where c.LabelId == label.LabelId
                           select c).FirstOrDefault();
                decimal previousLabelPrice = lab.Price;
                lab.Price = label.Price;
                lab.LabelName = label.LabelName;

                var weddingCakes = (from wc in _context.WeddingCakes
                                    where wc.LabelId == label.LabelId
                                    select wc).ToList();

                foreach (var wc in weddingCakes)
                {
                    wc.TotalPrice = wc.TotalPrice - previousLabelPrice + lab.Price;
                }
                _context.SaveChanges();
            }
            return true;
        }

        // levels
        public LevelsVM getLevels()
        {
            LevelsVM vm = new LevelsVM();
            vm.Levels = (from c in _context.Levels
                         select new Level
                         {
                             Price = c.Price,
                             LevelNumber = c.LevelNumber
                         }).ToList();
            return vm;
        }

        public bool EditLevels(LevelsVM levelsVM)
        {

            foreach (var level in levelsVM.Levels)
            {
                var lab = (from c in _context.Levels
                           where c.LevelNumber == level.LevelNumber
                           select c).FirstOrDefault();
                decimal previousLevelPrice = lab.Price;
                lab.Price = level.Price;
                lab.LevelNumber = level.LevelNumber;

                var weddingCakes = (from wc in _context.WeddingCakes
                                    where wc.LevelNumber == level.LevelNumber
                                    select wc).ToList();

                foreach (var wc in weddingCakes)
                {
                    wc.TotalPrice = wc.TotalPrice - previousLevelPrice + lab.Price;
                }
                _context.SaveChanges();
            }
            return true;
        }

        // decorations
        public DecorationsVM getDecorations()
        {
            DecorationsVM vm = new DecorationsVM();
            vm.Decorations = (from c in _context.Decorations
                              select new Decoration
                              {
                             Price = c.Price,
                             Decoration1 = c.Decoration1,
                             DecorationId = c.DecorationId
                         }).ToList();
            return vm;
        }

        public bool EditDecorations(DecorationsVM decorationsVM)
        {

            foreach (var decoration in decorationsVM.Decorations)
            {
                var lab = (from c in _context.Decorations
                           where c.DecorationId == decoration.DecorationId
                           select c).FirstOrDefault();
                decimal previousDecorationPrice = lab.Price;
                lab.Price = decoration.Price;

                var weddingCakeIds = (from wcd in _context.WeddingCakeDecorations
                                    where wcd.DecorationId == decoration.DecorationId
                                    select wcd.WeddingCakeId).Distinct().ToList();

                foreach (var wcId in weddingCakeIds)
                {
                    var weddingCake = (from wc in _context.WeddingCakes
                                       where wc.WeddingCakeId == wcId
                                       select wc).FirstOrDefault();
                    if(weddingCake != null)
                    {
                        weddingCake.TotalPrice = weddingCake.TotalPrice - previousDecorationPrice + lab.Price;
                    }
                }
                _context.SaveChanges();
            }
            return true;
        }
    }
}
