using StorageStation.Domain.Common;

namespace StorageStation.Domain.Models;

public sealed class Category : DomainEntity
{
    private List<Product> _products = new();
    private Category() { }
        
    public Category(string name, int householdId)
    {
        this.Name = name;
        this.HouseholdId = householdId;
    }
    public string Name { get; private set; }
    public int HouseholdId { get; private set; }

    public Household Household { get; private set; }

    public IReadOnlyCollection<Product> Products => this._products;
}