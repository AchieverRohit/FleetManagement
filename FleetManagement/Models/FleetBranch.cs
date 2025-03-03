namespace FleetManagement.Models
{
    public class FleetBranch
    {
        public Guid FleetBranchId { get; set; }
        public Guid FleetAccountId { get; set; } // Foreign Key to main FleetAccount
        public string BranchName { get; set; }
        public string Address { get; set; }

        public FleetAccount FleetAccount { get; set; } // Navigation Property
    }
}
