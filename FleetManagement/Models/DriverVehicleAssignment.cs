namespace FleetManagement.Models
{
    public class DriverVehicleAssignment
    {
        public Guid AssignmentId { get; set; }
        public Guid DriverId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime AssignedAt { get; set; }

        // Navigational Properties
        public DriverDetails Driver { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
