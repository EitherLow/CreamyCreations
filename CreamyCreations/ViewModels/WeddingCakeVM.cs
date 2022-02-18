using CreamyCreations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class WeddingCakeVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeddingCakeID { get; set; }

        public List<Cover> Covers { get; set; }
        public List<Filling> Fillings { get; set; }
        public List<Label> Labels { get; set; }
        public List<Level> Levels { get; set; }
        public List<Decoration> Decorations { get; set; } 
        public decimal TotalPrice { get; set; }
    }
}
