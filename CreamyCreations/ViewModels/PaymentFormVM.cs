namespace CreamyCreations.ViewModels
{
    public class PaymentFormVM
    {
        // Address
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public string Street { get; set; }
        public string Province { get; set; }

        // Data from the create page
        public string WeddingCakeId { get; set; }
        public string UserId { get; set; }

        // Order
        public string DeliveryDate { get; set; }       
    }
    
}
