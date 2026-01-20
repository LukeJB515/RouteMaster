namespace RouteMaster.DomainLayer.Entities
{
    public class Convoy
    {
        public int ConvoyId { get; set; }

        public string? ConvoyName { get; set; }
        public DateTime PlannedStartDate { get; set; }

        public string? Status { get; set; }
    }
}
