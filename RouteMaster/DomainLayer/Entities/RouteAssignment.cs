namespace RouteMaster.DomainLayer.Entities
{
    public class RouteAssignment
    {
        public int RouteAssignmentId { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public int StartingMileage { get; set; }

        public int ProjectedEndingMileage
        {
            get
            {
                return StartingMileage + (Route?.DistanceMiles ?? 0);
            }
        }

        public DateTime AssignedAt { get; set; }
        public bool IsCompleted { get; set; }

        public ICollection<RouteAssignmentMaterial>? RouteAssignmentMaterials { get; set; }

        public int? ConvoyId { get; set; }
        public Convoy? Convoy { get; set; }
    }
}
