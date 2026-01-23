namespace RouteMaster.DomainLayer.Entities
{
    public class Convoy
    {
        public int ConvoyId { get; set; }

        public string? ConvoyName { get; set; }

        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public DateTime PlannedAtUtc { get; set; } = DateTime.UtcNow;

        public string? Status { get; set; }

        public ICollection<ConvoyVehicle> Vehicles { get; set; }
            = new List<ConvoyVehicle>();

        public decimal StartingBudget { get; set; }
        public decimal TotalPlannedCost { get; set; }
        public bool IsOverBudget { get; set; }
    }
}
