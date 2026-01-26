namespace RouteMaster.DomainLayer.Entities
{
    public class Convoy
    {
        public int ConvoyId { get; set; }

        public string? ConvoyName { get; set; }

        public int RouteId { get; set; }
        public Route? Route { get; set; }

        public DateTime PlannedAtUtc { get; set; } = DateTime.UtcNow;

        public string? Status { get; set; }

        //public ICollection<ConvoyVehicle> Vehicles { get; set; }
        //    = new List<ConvoyVehicle>();

        public decimal StartingBudget { get; set; }
        public decimal TotalPlannedCost { get; set; }
        public bool IsOverBudget { get; set; }

        public bool IsPlanned { get; private set; }        

        private readonly List<Vehicle> _vehicles = new();

        public IReadOnlyCollection<Vehicle> Vehicles => _vehicles.AsReadOnly();

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            if (IsPlanned)
                throw new InvalidOperationException("Cannot add vehicles to a planned convoy.");

            _vehicles.Add(vehicle);
        }

        public void ValidateForPlanning()
        {
            if (!_vehicles.Any())
                throw new InvalidOperationException("Convoy must contain at least one vehicle.");

            if (IsPlanned)
                throw new InvalidOperationException("Convoy has already been planned.");
        }

        public void MarkPlanned()
        {
            if (IsPlanned)
                throw new InvalidOperationException("Convoy has already been planned.");

            IsPlanned = true;
        }
    }
}
