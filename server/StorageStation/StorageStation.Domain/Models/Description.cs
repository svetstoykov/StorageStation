namespace StorageStation.Domain.Models
{
    public sealed partial class Description
    {
        public Description()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int HouseholdId { get; set; }

        public Household Household { get; set; } = null!;
        public ICollection<Product> Products { get; set; }
    }
}
