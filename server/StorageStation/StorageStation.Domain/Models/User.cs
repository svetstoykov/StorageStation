namespace StorageStation.Domain.Models
{
    public sealed partial class User
    {
        public User()
        {
            ShoppingLists = new HashSet<ShoppingList>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int HouseholdId { get; set; }

        public Household Household { get; set; } = null!;
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
