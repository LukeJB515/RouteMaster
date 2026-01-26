using RouteMaster.ApplicationLayer.Services.Budget;
using RouteMaster.ApplicationLayer.Services.Maintenance;
using RouteMaster.ApplicationLayer.Services.Mileage;
using RouteMaster.Data;
using RouteMaster.DomainLayer.Entities;
using RouteMaster.Results;

namespace RouteMaster.ApplicationLayer.Services.Orchestration
{
    public class ConvoyPlanningService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly MileageFinalizationService? _mileageService;
        private readonly MaintenanceEvaluationService? _maintenanceService;
        private readonly BudgetAnalysisService? _budgetService;
        private readonly MaintenanceRecordService? _maintenanceRecordService;
        private readonly VehicleMileageService? _vehicleMileageService;
        //private readonly MileageFinalizationResult? _mileageResult;

        public ConvoyPlanningService(
            ApplicationDbContext dbContext,
            MileageFinalizationService? mileageService,
            MaintenanceEvaluationService? maintenanceService,
            BudgetAnalysisService? budgetService,
            MaintenanceRecordService? maintenanceRecordService,
            VehicleMileageService? vehicleMileageService/*,
            MileageFinalizationResult? mileageResult*/)
        {
            _dbContext = dbContext;
            _mileageService = mileageService;
            _maintenanceService = maintenanceService;
            _budgetService = budgetService;
            _maintenanceRecordService = maintenanceRecordService;
            _vehicleMileageService = vehicleMileageService;
            //_mileageResult = mileageResult;
        }

        public async Task<ConvoyPlanningResult> PlanConvoyAsync(
            Vehicle vehicle,
            Convoy convoy,
            RouteAssignment routeAssignment,
            IEnumerable<RouteAssignmentMaterial> materials,
            decimal startingBudget)
        {
            convoy.ValidateForPlanning();

            var mileageResult = _mileageService.FinalizeMileage(
                vehicle.CurrentMileage,
                routeAssignment.Route.DistanceMiles);

            await _vehicleMileageService.UpdateMileageAsync(
                vehicle,
                mileageResult.EndingMileage);

            var maintenanceResult = _maintenanceService.Evaluate(
                mileageResult.EndingMileage,
                vehicle/*.LastOilChangeMileage,
                vehicle.LastBrakeInspectionMileage,
                vehicle.LastTireInspectionMileage,
                vehicle.AirHosePressureMileage*/);

            await _maintenanceRecordService.RecordAsync(
                vehicle,
                mileageResult.EndingMileage,
                maintenanceResult);

            var budgetResult = _budgetService.Analyze(
                startingBudget,
                routeAssignment,
                materials,
                maintenanceResult);

            convoy.MarkPlanned();

            await _dbContext.SaveChangesAsync();

            return new ConvoyPlanningResult
            {
                MileageResult = mileageResult,
                MaintenanceResult = maintenanceResult,
                BudgetResult = budgetResult
            };
        }

        //below is just code I will be testing out later
        //following methods have yet to be defined: Finalize, EvaluateAndPersist,
        //Evaluate (in the Budget Services class, and Success.
        //public async Task<ConvoyPlanningResult> PlanAsync(Convoy convoy)
        //{
        //    convoy.ValidateForPlanning();

        //    _mileageService.Finalize(convoy);
        //    _maintenanceService.EvaluateAndPersist(convoy);
        //    _budgetService.Evaluate(convoy);

        //    convoy.MarkPlanned();

        //    await _dbContext.SaveChangesAsync();

        //    return ConvoyPlanningResult.Success(convoy.ConvoyId);
        //}
    }
}
