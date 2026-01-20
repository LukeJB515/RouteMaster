namespace RouteMaster.DomainLayer.Entities
{
    public class Route
    {
        public int RouteId { get; set; }

        public string? RouteTitle { get; set; }
        public string? StartPoint { get; set; }
        public string? MainDestination { get; set; }

        public int DistanceMiles { get; set; }

        public string? TerrainType { get; set; }
    }
}
