namespace RouteMaster.DomainLayer.Entities
{
    public class ConvoyVehicle
    {
        public int Id { get; set; }

        public int ConvoyId { get; set; }
        public Convoy? Convoy { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int StartingMileage { get; set; }
        public int EndingMileage { get; set; }

        public bool RequiresMaintenance { get; set; }
    }
}
