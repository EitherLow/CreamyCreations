using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.ViewModels
{
    public class WeddingCakeVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WeddingCakeId { get; set; }

        public int CoverId { get; set; }
        public int FillingId { get; set; }
        public int LabelId { get; set; }
        public int LevelNumber { get; set; }
        public List<int> DecorationId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
