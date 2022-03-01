using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CreamyCreations.ViewModels
{
    public class CustomerWeddingCakeVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Order ID")]
        public int orderID { get; set; }

        [Display(Name = "Customer ID")]
        public int userID { get; set; }

        [Display(Name = "Customer First Name")]
        public string firstName { get; set; }

        [Display(Name = "Customer Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Wedding Cake ID")]
        public int weddingCakeID { get; set; }

        [Display(Name = "Cake Cover")]
        public string cover { get; set; }

        [Display(Name = "Levels")]
        public int level { get; set; }

        [Display(Name = "Cake Label")]
        public string label { get; set; }

        [Display(Name = "Filling")]
        public string filling { get; set; }

        [Display(Name = "Decoration")]
        public string decoration { get; set; }

        [Display(Name = "Delivery Date")]
        public string deliveryDate { get; set; }

        [Display(Name = "Price")]
        public string price { get; set; }
    }
}
