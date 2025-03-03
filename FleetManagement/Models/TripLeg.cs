namespace FleetManagement.Models
{
    public class TripLeg
    {
        public Guid TripLegId { get; set; }
        public Guid TripId { get; set; }

        public string StartLocation { get; set; }
        public string EndLocation { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public decimal Distance { get; set; } // Leg-specific distance
        public decimal Cost { get; set; } // Cost per leg (fuel, tolls, etc.)

        public Trip Trip { get; set; }
    }
}
