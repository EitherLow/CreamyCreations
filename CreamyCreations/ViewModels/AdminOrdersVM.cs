using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CreamyCreations.ViewModels
{
    public class AdminOrdersVM
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Order ID")]
        public int orderID { get; set; }

        [Display(Name = "Wedding Cake ID")]
        public int weddingCakeID { get; set; }

        [Display(Name = "Customer ID")]
        public int userID { get; set; }

        [Display(Name = "Delivery Date")]
        public string deliveryDate { get; set; }

        [Display(Name = "Price")]
        public string price { get; set; }
    }
}
