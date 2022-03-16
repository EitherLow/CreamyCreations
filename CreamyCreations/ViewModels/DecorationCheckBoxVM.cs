using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class DecorationCheckBoxVM
    {
        [Key]
        public int DecorationId { get; set; }
        public decimal Price { get; set; }
        public string DecorationTitle { get; set; }
        public bool IsChecked { get; set; }
    }
}
