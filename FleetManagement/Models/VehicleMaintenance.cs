namespace FleetManagement.Models
{
    public class VehicleMaintenance
    {
        public Guid MaintenanceId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }

        // Navigational Properties
        public Vehicle Vehicle { get; set; }
    }
}
