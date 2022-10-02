using StorageStation.Domain.Common;

namespace StorageStation.Domain.Models;

public sealed class Household : DomainEntity
{
    private List<Category> _categories = new();
    private List<Location> _locations = new();
    private List<Product> _products = new();
    private List<User> _users = new();

    private Household() { }
        
    public Household(string name)
    {
        this.Name = name;
    }
    public string Name { get; private set; }

    public IReadOnlyCollection<Category> Categories => this._categories.AsReadOnly();

    public IReadOnlyCollection<Location> Locations => this._locations.AsReadOnly();

    public IReadOnlyCollection<Product> Products => this._products.AsReadOnly();

    public IReadOnlyCollection<User> Users => this._users.AsReadOnly();

    public void AddUserToHousehold(User user)
        => this._users.Add(user);
}