using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CreamyCreations.Models;

namespace CreamyCreations.ViewModels
{
    public class PaymentVM
    {
        [Key]
        public int WeddingCakeId { get; set; }
        public List<Filling> Fillings { get; set; }
        public List<Cover>  Covers { get; set; }
        public List<Decoration> Decorations { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
