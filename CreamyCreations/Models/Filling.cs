using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Filling
    {
        public Filling()
        {
            WeddingCakes = new HashSet<WeddingCake>();
        }

        public int FillingId { get; set; }
        public decimal Price { get; set; }
        public string Flavor { get; set; }

        public virtual ICollection<WeddingCake> WeddingCakes { get; set; }
    }
}
