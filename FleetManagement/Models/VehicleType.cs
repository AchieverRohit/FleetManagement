namespace FleetManagement.Models
{
    public class VehicleType
    {
        public Guid VehicleTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        // Navigational Properties
        public ICollection<VehicleInfo> Vehicles { get; set; }
    }
}
