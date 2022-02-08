using System;
using System.Collections.Generic;

#nullable disable

namespace CreamyCreations.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public int WeddingCakeId { get; set; }
        public int UserId { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual WeddingCake WeddingCake { get; set; }
    }
}
