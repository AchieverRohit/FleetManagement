namespace FleetManagement.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public Guid VehicleTypeId { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string CurrentStatus { get; set; }
        public Guid FleetAccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }

        // Navigational Properties
        public VehicleType VehicleType { get; set; }
        public ICollection<Trip> Trips { get; set; }
        public ICollection<VehicleMaintenance> VehicleMaintenances { get; set; }
        public ICollection<FuelLog> FuelLogs { get; set; }
        public FleetAccount FleetAccount { get; set; }
        //public ICollection<Document> Documents { get; set; }
    }
}
