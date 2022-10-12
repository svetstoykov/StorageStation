using StorageStation.Domain.Common;
using StorageStation.Domain.Users;

namespace StorageStation.Domain.ShoppingLists;

public sealed class ShoppingList : DomainEntity
{
    private List<Item> _items = new();

    private ShoppingList() { }

    public ShoppingList(int createdByUserId, DateTime dateCreated)
    {
        this.CreatedByUserId = createdByUserId;
        this.DateCreated = dateCreated;
    }

    public DateTime DateCreated { get; private set;}
    public DateTime? DateCompleted { get; private set;}
    public int CreatedByUserId { get; private set;}

    public User CreatedByUser { get; private set;}
    public IReadOnlyCollection<Item> Items => this._items.AsReadOnly();

    public void AddItemToShoppingList(Item item)
        =>
            this._items.Add(item);
}