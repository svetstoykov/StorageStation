using StorageStation.Domain.Common;
using StorageStation.Domain.ShoppingLists;

namespace StorageStation.Domain.Users;

public sealed class User : DomainEntity
{
    private List<ShoppingList> _shoppingLists = new();

    private User()
    {
    }

    public User(string username, string email, string fullName, string passwordHash, int? householdId = null)
    {
        this.Username = username;
        this.Email = email;
        this.FullName = fullName;
        this.PasswordHash = passwordHash;
        this.HouseholdId = householdId;
    }

    public string Username { get; private set; }
    public string FullName { get; private set; }
    public string PasswordHash { get; private set; }
    public int? HouseholdId { get; private set; }
    public string Email { get; private set; }

    public bool IsAdmin { get; private set; }
    public Household Household { get; private set; } 

    public IReadOnlyCollection<ShoppingList> ShoppingLists => this._shoppingLists.AsReadOnly();

    public void UpdateUserAdminStatus(bool isAdmin)
        => this.IsAdmin = isAdmin;
}