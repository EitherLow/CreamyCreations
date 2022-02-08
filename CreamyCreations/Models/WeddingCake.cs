using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class WeddingCake
    {
        public WeddingCake()
        {
            Orders = new HashSet<Order>();
            WeddingCakeDecorations = new HashSet<WeddingCakeDecoration>();
        }

        public int WeddingCakeId { get; set; }
        public int CoverId { get; set; }
        public int FillingId { get; set; }
        public int LabelId { get; set; }
        public int LevelNumber { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Cover Cover { get; set; }
        public virtual Filling Filling { get; set; }
        public virtual Label Label { get; set; }
        public virtual Level LevelNumberNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<WeddingCakeDecoration> WeddingCakeDecorations { get; set; }
    }
}
