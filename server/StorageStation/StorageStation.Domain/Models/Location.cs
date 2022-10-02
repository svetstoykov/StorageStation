using StorageStation.Domain.Common;

namespace StorageStation.Domain.Models
{
    public sealed class Location : DomainEntity
    {
        private List<StoredItem> _storedItems = new();

        public Location(string name, int householdId, string coordinates = null)
        {
            this.Name = name;
            this.HouseholdId = householdId;
            this.Coordinates = coordinates;
        }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public int HouseholdId { get; set; }

        public Household Household { get; set; }
        public IReadOnlyCollection<StoredItem> StoredItems => this._storedItems.AsReadOnly();

        public void StoreItemInLocation(StoredItem item)
            =>
                this._storedItems.Add(item);
    }
}
