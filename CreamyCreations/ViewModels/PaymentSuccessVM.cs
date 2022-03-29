using System.ComponentModel.DataAnnotations;

namespace CreamyCreations.ViewModels
{
    public class PaymentSuccessVM
    {
        [Key]
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
    }
}
