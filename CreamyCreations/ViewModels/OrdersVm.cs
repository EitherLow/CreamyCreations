using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class OrdersVm
    {
        [Key]
        public int OrderId { get; set; }

        public string Date { get; set; }

        public string price { get; set; }
    }
}
