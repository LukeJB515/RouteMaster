namespace RouteMaster
{
    public class BudgetAnalysisResult
    {
        public decimal StartingBudget { get; set; }

        public decimal DistanceCost { get; set; }
        public decimal CargoCost { get; set; }
        public decimal MaintenanceCost { get; set; }

        public decimal TotalCost => DistanceCost + CargoCost + MaintenanceCost;

        public decimal RemainingBudget => StartingBudget - TotalCost;

        public bool IsOverBudget => RemainingBudget < 0;
    }
}
