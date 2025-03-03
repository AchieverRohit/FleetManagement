namespace FleetManagement.Models
{
    public class CustomerInfo
    {
        public Guid CustomerInfoId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; } // New Field: Address
        public Guid FleetAccountId { get; set; }

        // Navigational Properties
        public FleetAccount FleetAccount { get; set; }
        public ICollection<Trip> Trips { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
