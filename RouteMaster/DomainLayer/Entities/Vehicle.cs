namespace RouteMaster.DomainLayer.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        public string? VehicleManufacturer { get; set; }
        public string? VehicleType { get; set; } //example: semi-truck/18 wheeler or humvee, etc
        public string? VehicleColor { get; set; } //multiple identifiers are necessary
        public string? SerialNumber { get; set; } //may be needed for maintenance and legal purposes
        public string? TagId { get; set; } //needs to be entered by user for DMV registration

        public decimal EmptyWeight { get; set; }
        public decimal MaxPayload { get; set; }

        public int CurrentMileage { get; set; }

        public int LastOilChangeMileage { get; set; }
        public int LastBrakeInspectionMileage { get; set; }
        public int LastTireInspectionMileage { get; set; }
        public int AirHosePressureMileage { get; set; }
        //may need to add more maintenance tracking later

        //public ICollection<VehicleEquipment> VehicleEquipment { get; set; }
        //separating vehicle equipment as equip that relates to needs of vehicle from
        //materials loaded onto vehicle's trailer....
        //for instance, vehicle equipment could relate to spare tire or fire extinguisher, etc
        //materials loaded onto trailer relate more to goods being shipped.
    }
}
