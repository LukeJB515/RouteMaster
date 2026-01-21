using RouteMaster.ApplicationLayer.Services.Budget;
using RouteMaster.ApplicationLayer.Services.Maintenance;
using RouteMaster.ApplicationLayer.Services.Mileage;
using RouteMaster.DomainLayer.Entities;
using RouteMaster.Results;

namespace RouteMaster.ApplicationLayer.Services.Orchestration
{
    public class ConvoyPlanningService
    {
        private readonly MileageFinalizationService? _mileageService;
        private readonly MaintenanceEvaluationService? _maintenanceService;
        private readonly BudgetAnalysisService? _budgetService;
        //private readonly MileageFinalizationResult? _mileageResult;

        public ConvoyPlanningService(
            MileageFinalizationService? mileageService,
            MaintenanceEvaluationService? maintenanceService,
            BudgetAnalysisService? budgetService/*,
            MileageFinalizationResult? mileageResult*/)
        {
            _mileageService = mileageService;
            _maintenanceService = maintenanceService;
            _budgetService = budgetService;
            //_mileageResult = mileageResult;
        }

        public ConvoyPlanningResult PlanConvoy(
            Vehicle vehicle,            
            RouteAssignment routeAssignment,
            IEnumerable<RouteAssignmentMaterial> materials,
            decimal startingBudget)
        {
            var mileageResult = _mileageService.FinalizeMileage(
                vehicle.CurrentMileage,
                routeAssignment.Route.DistanceMiles);

            var maintenanceResult = _maintenanceService.Evaluate(
                mileageResult.EndingMileage,
                vehicle/*.LastOilChangeMileage,
                vehicle.LastBrakeInspectionMileage,
                vehicle.LastTireInspectionMileage,
                vehicle.AirHosePressureMileage*/);

            var budgetResult = _budgetService.Analyze(
                startingBudget,
                routeAssignment,
                materials,
                maintenanceResult);

            return new ConvoyPlanningResult
            {
                MileageResult = mileageResult,
                MaintenanceResult = maintenanceResult,
                BudgetResult = budgetResult
            };
        }
    }
}
