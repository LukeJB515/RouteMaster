namespace RouteMaster.DomainLayer.Entities
{
    public class ConvoyVehicle
    {
        //protected ConvoyVehicle() { }

        //public ConvoyVehicle(Convoy convoy, Vehicle vehicle)
        //{
        //    Convoy = convoy ?? throw new ArgumentNullException(nameof(convoy));
        //    Vehicle = vehicle ?? throw new ArgumentNullException(nameof(vehicle));

        //    ConvoyId = convoy.ConvoyId;
        //    VehicleId = vehicle.VehicleId;
        //}

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
