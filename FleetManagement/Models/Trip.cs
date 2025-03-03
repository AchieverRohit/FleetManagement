namespace FleetManagement.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }
        public Guid VehicleInfoId { get; set; }
        public Guid DriverInfoId { get; set; }
        public Guid? CustomerInfoId { get; set; }
        public Guid FleetBranchId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TripDate { get; set; }
        public string TripStatus { get; set; }

        // Navigational Properties
        public VehicleInfo Vehicle { get; set; }
        public DriverInfo Driver { get; set; }
        public CustomerInfo Customer { get; set; }
        public ICollection<TripLeg> TripLegs { get; set; }
        public FleetBranch FleetBranch { get; set; }

    }
}
