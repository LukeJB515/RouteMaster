namespace RouteMaster.DomainLayer.Entities
{
    public class RouteAssignmentMaterial
    {
        public int RouteAssignmentMaterialId { get; set; }

        public int RouteAssignmentId { get; set; }
        public RouteAssignment? RouteAssignment { get; set; }

        public int MaterialsToLoadId { get; set; }
        public MaterialsToLoad? MaterialsToLoad { get; set; }

        public int Quantity { get; set; }
    }
}
