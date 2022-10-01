namespace StorageStation.Domain.Models
{
    public sealed class User
    {
        public User()
        {
            ShoppingLists = new HashSet<ShoppingList>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int HouseholdId { get; set; }
        public string Email { get; set; } = null!;

        public Household Household { get; set; } = null!;
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
