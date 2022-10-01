namespace StorageStation.Domain.Models
{
    public sealed partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int HouseholdId { get; set; }

        public Household Household { get; set; } = null!;
        public ICollection<Product> Products { get; set; }
    }
}
