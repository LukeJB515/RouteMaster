using RouteMaster.Data;
using RouteMaster.DomainLayer.Entities;

namespace RouteMaster.ApplicationLayer.Services.Mileage
{
    public class VehicleMileageService
    {
        private readonly ApplicationDbContext _context;

        public VehicleMileageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateMileageAsync(
            Vehicle vehicle,
            int newMileage)
        {
            if (newMileage < vehicle.CurrentMileage)
            {
                throw new InvalidOperationException("New mileage cannot be less than current mileage.");
            }

            vehicle.CurrentMileage = newMileage;

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}
