using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Label
    {
        public Label()
        {
            WeddingCakes = new HashSet<WeddingCake>();
        }

        public int LabelId { get; set; }
        public string LabelName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<WeddingCake> WeddingCakes { get; set; }
    }
}
