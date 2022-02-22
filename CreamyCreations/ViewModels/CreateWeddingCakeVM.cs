using CreamyCreations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class CreateWeddingCakeVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeddingCakeId { get; set; }

        public int CoverId { get; set; }
        public List<Cover> Covers { get; set; }
        public int FillingId { get; set; }
        public List<Filling> Fillings { get; set; }
        public int LabelId { get; set; }
        public List<Label> Labels { get; set; }
        public int LevelId { get; set; }
        public List<Level> Levels { get; set; }
        public List<Decoration> Decorations { get; set; } 
        public decimal TotalPrice { get; set; }
    }
}
