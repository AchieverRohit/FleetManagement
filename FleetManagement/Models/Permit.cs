namespace FleetManagement.Models
{
    public class Permit
    {
        public Guid PermitId { get; set; } 
        public Guid VehicleId { get; set; } 
        public string PermitType { get; set; } // e.g., Commercial, Environmental, etc.
        public string IssuedBy { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string DocumentPath { get; set; } // Path to the permit file

        // Navigational Properties
        public Vehicle Vehicle { get; set; }
        //public ICollection<Document> Documents { get; set; }
    }
}
