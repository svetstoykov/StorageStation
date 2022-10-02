using StorageStation.Domain.Common;

namespace StorageStation.Domain.Models
{
    public sealed class Product : DomainEntity
    {
        private List<Item> _items = new();
        private List<StoredItem> _storedItems = new ();

        private Product()
        {
        }

        public Product(string name, int categoryId, int householdId, string content = null)
        {
            this.Name = name;
            this.CategoryId = categoryId;
            this.HouseholdId = householdId;
        }

        public string Content { get; private set; }
        public string Name { get; private set; } 
        public int HouseholdId { get; private set; }
        public int CategoryId { get; private set; }

        public Category Category { get; private set; }
        public Household Household { get; private set; }

        public IReadOnlyCollection<Item> Items => this._items.AsReadOnly();

        public IReadOnlyCollection<StoredItem> StoredItems => this._storedItems.AsReadOnly();
    }
}
