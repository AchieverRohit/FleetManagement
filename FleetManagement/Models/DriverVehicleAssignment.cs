namespace FleetManagement.Models
{
    public class DriverVehicleAssignment
    {
        public Guid DriverVehicleAssignmentId { get; set; }
        public Guid AssignmentId { get; set; }
        public Guid DriverInfoId { get; set; }
        public Guid VehicleInfoId { get; set; }
        public DateTime AssignedAt { get; set; }
        public DateTime? UnassignedAt { get; set; } 
        public bool IsActive { get; set; } = true;
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        // Navigational Properties
        public DriverInfo Driver { get; set; }
        public VehicleInfo Vehicle { get; set; }
    }
}
