using RouteMaster.DomainLayer.Entities;
using RouteMaster.Maintenance;

namespace RouteMaster.ApplicationLayer.Services
{
    public class BudgetAnalysisService
    {
        public BudgetAnalysisResult Analyze(
            decimal startingBudget,
            RouteAssignment routeAssignment,
            IEnumerable<RouteAssignmentMaterial> materials,
            MaintenanceEvaluationResult maintenanceResult)
        {
            var result = new BudgetAnalysisResult
            {
                StartingBudget = startingBudget
            };

            result.DistanceCost =
                routeAssignment.Route.DistanceMiles * BudgetRates.CostPerMile;

            var totalCargoWeight = materials.Sum(m =>
            m.MaterialsToLoad.Weight * m.Quantity);

            result.CargoCost =
                totalCargoWeight * BudgetRates.CostPerCargoPound;

            if (maintenanceResult.OilChangeRequired)
                result.MaintenanceCost += BudgetRates.OilChangeCost;

            if (maintenanceResult.BrakeInspectionRequired)
                result.MaintenanceCost += BudgetRates.BrakeInspectionCost;

            if (maintenanceResult.TireInspectionRequired)
                result.MaintenanceCost += BudgetRates.TireInspectionCost;

            if (maintenanceResult.AirHoseInspectionRequired)
                result.MaintenanceCost += BudgetRates.AirPressureCost;

            return result;
        }
    }
}
