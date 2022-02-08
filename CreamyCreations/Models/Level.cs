using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Level
    {
        public Level()
        {
            WeddingCakes = new HashSet<WeddingCake>();
        }

        public int LevelNumber { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<WeddingCake> WeddingCakes { get; set; }
    }
}
