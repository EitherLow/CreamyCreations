using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Decoration
    {
        public Decoration()
        {
            WeddingCakeDecorations = new HashSet<WeddingCakeDecoration>();
        }

        public int DecorationId { get; set; }
        public decimal Price { get; set; }
        public string Decoration1 { get; set; }

        public virtual ICollection<WeddingCakeDecoration> WeddingCakeDecorations { get; set; }
    }
}
