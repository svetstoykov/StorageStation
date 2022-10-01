namespace StorageStation.Domain.Models
{
    public sealed partial class Location
    {
        public Location()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Coordinates { get; set; }
        public int HouseholdId { get; set; }

        public Household Household { get; set; } = null!;
        public ICollection<Product> Products { get; set; }
    }
}
