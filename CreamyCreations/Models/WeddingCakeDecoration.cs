using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class WeddingCakeDecoration
    {
        public int WeddingCakeId { get; set; }
        public int DecorationId { get; set; }

        public virtual Decoration Decoration { get; set; }
        public virtual WeddingCake WeddingCake { get; set; }
    }
}
