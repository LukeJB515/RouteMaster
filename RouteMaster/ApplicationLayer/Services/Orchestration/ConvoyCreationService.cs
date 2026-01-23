using RouteMaster.Data;
using RouteMaster.DomainLayer.Entities;
using Microsoft.AspNetCore.Routing;
using RouteMaster.Results;

namespace RouteMaster.ApplicationLayer.Services.Orchestration
{
    public class ConvoyCreationService
    {
        private readonly ApplicationDbContext _context;

        public ConvoyCreationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Convoy> CreateAsync(
            string name,
            //Route route,
            Vehicle vehicle,
            ConvoyPlanningResult planningResult,
            decimal startingBudget)
        {
            var convoy = new Convoy
            {
                ConvoyName = name,
                //RouteId = route.Id,
                StartingBudget = startingBudget,
                TotalPlannedCost = planningResult.BudgetResult.TotalCost,
                IsOverBudget = planningResult.BudgetResult.IsOverBudget
            };

            convoy.Vehicles.Add(new ConvoyVehicle
            {
                VehicleId = vehicle.VehicleId,
                StartingMileage = planningResult.MileageResult.StartingMileage,
                EndingMileage = planningResult.MileageResult.EndingMileage,
                RequiresMaintenance =
                    planningResult.MaintenanceResult.OilChangeRequired ||
                    planningResult.MaintenanceResult.BrakeInspectionRequired ||
                    planningResult.MaintenanceResult.TireInspectionRequired ||
                    planningResult.MaintenanceResult.AirHoseInspectionRequired
            });

            _context.Convoys.Add(convoy);
            await _context.SaveChangesAsync();

            return convoy;
        }
    }
}
