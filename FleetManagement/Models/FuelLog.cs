namespace FleetManagement.Models
{
    public class FuelLog
    {
        public Guid FuelLogId { get; set; }
        public Guid VehicleId { get; set; }
        public DateTime RefuelDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }

        // Navigational Properties
        public Vehicle Vehicle { get; set; }
    }
}
