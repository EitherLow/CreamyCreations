﻿using System;
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

        public int weddingCakeID { get; set; }

        public int userID { get; set; }

        public DateTime deliveryDate { get; set; }
    }
}
