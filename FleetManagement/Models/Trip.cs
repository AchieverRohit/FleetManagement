namespace FleetManagement.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid DriverId { get; set; }
        public Guid? CustomerId { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TripStatus { get; set; }
        public decimal? DistanceTravelled { get; set; }

        // Navigational Properties
        public Vehicle Vehicle { get; set; }
        public DriverDetails Driver { get; set; }
        public CustomerDetail Customer { get; set; }
    }
}
