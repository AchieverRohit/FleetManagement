namespace FleetManagement.Models
{
    public class Invoice
    {
        public Guid InvoiceId { get; set; } 
        public Guid CustomerInfoId { get; set; }
        public Guid? TripId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } 
        public DateTime? DueDate { get; set; }

        // Navigational Properties
        public CustomerInfo Customer { get; set; }
        public Trip Trip { get; set; }
    }
}
