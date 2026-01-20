namespace RouteMaster.DomainLayer.Entities
{
    public class MaintenanceRecord
    {
        public int MaintenanceRecordId { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }

        public string? MaintenanceType { get; set; }

        public int MileageAtService { get; set; }
        public DateTime ServiceDate { get; set; }

        public string? Notes { get; set; } //will require a limited character count        
    }
}
