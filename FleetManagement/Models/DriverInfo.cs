using System.Reflection.Metadata;

namespace FleetManagement.Models
{
    public class DriverInfo
    {
        public Guid DriverInfoId { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime HireDate { get; set; }
        public string DriverStatus { get; set; }
        public decimal Salary { get; set; } // New: Compensation details
        public string PaymentMethod { get; set; }
        public Guid FleetAccountId { get; set; }

        // Navigational Properties
        public ICollection<Trip> Trips { get; set; }
        public ICollection<DriverVehicleAssignment> VehicleAssignments { get; set; }
        //public ICollection<Document> Documents { get; set; }
        public ApplicationUser User { get; set; }
        public FleetAccount FleetAccount { get; set; }
    }
}
