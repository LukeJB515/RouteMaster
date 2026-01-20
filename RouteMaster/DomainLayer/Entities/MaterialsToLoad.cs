namespace RouteMaster.DomainLayer.Entities
{
    public class MaterialsToLoad
    {
        public int CargoId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }

        public decimal Weight { get; set; }
        public decimal Cost { get; set; }

        public int Quantity { get; set; }
    }
}
