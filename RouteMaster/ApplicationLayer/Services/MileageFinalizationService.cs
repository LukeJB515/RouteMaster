using Microsoft.EntityFrameworkCore;
using RouteMaster.Data;

namespace RouteMaster.ApplicationLayer.Services
{
    public class MileageFinalizationService
    {
        private readonly ApplicationDbContext? _context;

        public MileageFinalizationService(ApplicationDbContext? context)
        {
            _context = context;
        }

        public void FinalizeRouteAssignment(int routeAssignmentId)
        {
            var assignment = _context.RouteAssignments
                .Include(ra => ra.Route)
                .Include(ra => ra.Vehicle)
                .FirstOrDefault(ra => ra.RouteAssignmentId == routeAssignmentId);

            if (assignment == null)
                throw new InvalidOperationException("Route assignment not found.");

            if (assignment.IsCompleted)
                throw new InvalidOperationException("Route assignment has already been completed.");

            var endingMileage = assignment.ProjectedEndingMileage;

            assignment.IsCompleted = true;
            assignment.CompletedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
