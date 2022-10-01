namespace StorageStation.Domain.Models
{
    public sealed class Product
    {
        public Product()
        {
            Items = new HashSet<Item>();
            StoredItems = new HashSet<StoredItem>();
        }

        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int HouseholdId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
        public Household Household { get; set; } = null!;
        public ICollection<Item> Items { get; set; }
        public ICollection<StoredItem> StoredItems { get; set; }
    }
}
