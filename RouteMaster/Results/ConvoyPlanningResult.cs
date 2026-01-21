using RouteMaster.ApplicationLayer.Services.Mileage;
using RouteMaster.Maintenance;

namespace RouteMaster.Results
{
    public class ConvoyPlanningResult
    {
        public MileageFinalizationResult? MileageResult { get; set; }
        public MaintenanceEvaluationResult? MaintenanceResult { get; set; }
        public BudgetAnalysisResult? BudgetResult { get; set; }

        public bool IsOverBudget => BudgetResult.IsOverBudget;
    }
}
