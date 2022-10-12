using StorageStation.Domain.Common;
using StorageStation.Domain.Users;

namespace StorageStation.Domain.Products;

public sealed class Category : DomainEntity
{
    private List<Product> _products = new();
    private Category() { }
        
    public Category(int id, string name, int householdId)
    {
        this.Id = id;
        this.Name = name;
        this.HouseholdId = householdId;
    }
    public string Name { get; private set; }
    public int HouseholdId { get; private set; }

    public Household Household { get; private set; }

    public IReadOnlyCollection<Product> Products => this._products;
}