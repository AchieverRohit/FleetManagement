namespace FleetManagement.Models
{
    public class FuelLog
    {
        public Guid FuelLogId { get; set; }
        public Guid VehicleInfoId { get; set; }
        public string FuelType { get; set; } // New: Petrol, Diesel, Electric
        public decimal FuelAmount { get; set; } // New: In liters/gallons
        public decimal PricePerUnit { get; set; } // New: Cost per liter/gallon
        public decimal TotalCost { get; set; } // New: Auto-calculate

        public DateTime RefueledAt { get; set; }
        public Guid? DriverId { get; set; }

        // Navigational Properties
        public VehicleInfo Vehicle { get; set; }
        public DriverInfo Driver { get; set; }
    }
}
