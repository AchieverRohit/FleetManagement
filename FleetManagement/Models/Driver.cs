using System.Reflection.Metadata;

namespace FleetManagement.Models
{
    public class DriverDetails
    {
        public Guid DriverId { get; set; }
        public string LicenseNumber { get; set; }
        public string EmergencyContact { get; set; }
        public DateTime HireDate { get; set; }
        public string DriverStatus { get; set; }
        public Guid FleetAccountId { get; set; }

        // Navigational Properties
        public ICollection<Trip> Trips { get; set; }
        //public ICollection<Document> Documents { get; set; }
        public ApplicationUser User { get; set; }
        public FleetAccount FleetAccount { get; set; }
    }
}
