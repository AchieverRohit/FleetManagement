namespace FleetManagement.Models
{
    public class FleetAccount
    {
        public Guid FleetAccountId { get; set; }
        public string FleetAccountName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PrimaryContact {  get; set; }

        public ICollection<FleetBranch> Branches { get; set; }
    }
}
