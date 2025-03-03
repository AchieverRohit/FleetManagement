namespace FleetManagement.Models
{
    public class UserFleetBranch
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid FleetBranchId { get; set; }
        public FleetBranch FleetBranch { get; set; }
    }
}
