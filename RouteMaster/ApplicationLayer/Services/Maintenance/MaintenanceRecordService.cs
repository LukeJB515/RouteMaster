using RouteMaster.Data;
using RouteMaster.DomainLayer.Entities;
using RouteMaster.Maintenance;

namespace RouteMaster.ApplicationLayer.Services.Maintenance
{
    public class MaintenanceRecordService
    {
        private readonly ApplicationDbContext _context;

        public MaintenanceRecordService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task RecordAsync(
            Vehicle vehicle,
            int mileageAtEvaluation,
            MaintenanceEvaluationResult evaluation)
        {
            if (!evaluation.OilChangeRequired &&
                !evaluation.BrakeInspectionRequired &&
                !evaluation.TireInspectionRequired &&
                !evaluation.AirHoseInspectionRequired)
            {
                return;
            }

            var record = new MaintenanceRecord
            {
                VehicleId = vehicle.VehicleId,
                MileageAtEvaluation = mileageAtEvaluation,
                OilChangeRequired = evaluation.OilChangeRequired,
                BrakeInspectionRequired = evaluation.BrakeInspectionRequired,                
                TireInspectionRequired = evaluation.TireInspectionRequired,
                AirHoseInspectionRequired = evaluation.AirHoseInspectionRequired,
                RecordedAtUtc = DateTime.UtcNow
            };

            _context.MaintenanceRecords.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}
