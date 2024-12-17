namespace FleetManagement.Models
{
    public class CustomerDetail
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        // Navigational Properties
        public ICollection<Trip> Trips { get; set; }
    }
}
