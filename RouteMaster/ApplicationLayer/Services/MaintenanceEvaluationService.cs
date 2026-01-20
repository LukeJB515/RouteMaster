using RouteMaster.DomainLayer.Entities;
using RouteMaster.Maintenance;

namespace RouteMaster.ApplicationLayer.Services
{
    public class MaintenanceEvaluationService
    {
        public MaintenanceEvaluationResult Evaluate(Vehicle vehicle)
        {
            var result = new MaintenanceEvaluationResult();
            //this class draws from Vehicles, MaintenanceIntervals and MaintenanceEvaluationResult
            if (vehicle.CurrentMileage - vehicle.LastOilChangeMileage >= MaintenanceIntervals.OilChangeMiles)
            {
                result.OilChangeRequired = true;
            }

            if (vehicle.CurrentMileage - vehicle.LastBrakeInspectionMileage >= MaintenanceIntervals.BrakeInspectionMiles)
            {
                result.BrakeInspectionRequired = true;
            }

            if (vehicle.CurrentMileage - vehicle.LastTireInspectionMileage >= MaintenanceIntervals.TireInspectionMiles)
            {
                result.TireInspectionRequired = true;
            }

            if (vehicle.CurrentMileage - vehicle.AirHosePressureMileage >= MaintenanceIntervals.AirHosePressureMiles)
            {
                result.AirHoseInspectionRequired = true;
            }

            return result;
        }
    }
}
