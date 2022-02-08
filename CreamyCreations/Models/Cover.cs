using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Cover
    {
        public Cover()
        {
            WeddingCakes = new HashSet<WeddingCake>();
        }

        public int CoverId { get; set; }
        public decimal Price { get; set; }
        public string Flavor { get; set; }

        public virtual ICollection<WeddingCake> WeddingCakes { get; set; }
    }
}
