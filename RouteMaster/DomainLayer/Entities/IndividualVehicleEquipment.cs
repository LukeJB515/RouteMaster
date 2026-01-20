namespace RouteMaster.DomainLayer.Entities
{
    public class IndividualVehicleEquipment
    {
        public int PermanentEquipmentId { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }

        public decimal Weight { get; set; }

        public bool IsRequired { get; set; }
    }
}
