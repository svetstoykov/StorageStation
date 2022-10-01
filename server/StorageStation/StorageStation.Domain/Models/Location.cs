namespace StorageStation.Domain.Models
{
    public sealed class Location
    {
        public Location()
        {
            StoredItems = new HashSet<StoredItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Coordinates { get; set; }
        public int HouseholdId { get; set; }

        public Household Household { get; set; } = null!;
        public ICollection<StoredItem> StoredItems { get; set; }
    }
}
