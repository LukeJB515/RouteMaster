namespace RouteMaster.Maintenance
{
    public class MaintenanceEvaluationResult
    {
        public bool OilChangeRequired { get; set; }
        public bool BrakeInspectionRequired { get; set; }
        public bool TireInspectionRequired { get; set; }
        public bool AirHoseInspectionRequired { get; set; }
    }
}
