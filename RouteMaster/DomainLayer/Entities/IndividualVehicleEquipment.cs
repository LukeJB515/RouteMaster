namespace RouteMaster.DomainLayer.Entities
{
    public class IndividualVehicleEquipment
    {
        public int PermanentEquipmentId { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public string? Equipment { get; set; } //spare tire, extinguisher
        public string? Category { get; set; } //emergency/company owned or personal - maybe the driver has his bed in the truck
        //choosing a vehicle with a bed in the truck may be necessary for cross country hauls, some trucks are local based

        public decimal Weight { get; set; }

        public bool IsRequired { get; set; }
    }
}
