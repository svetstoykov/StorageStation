namespace StorageStation.Domain.Models
{
    public sealed partial class Household
    {
        public Household()
        {
            Categories = new HashSet<Category>();
            Descriptions = new HashSet<Description>();
            Locations = new HashSet<Location>();
            ShoppingLists = new HashSet<ShoppingList>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Category> Categories { get; set; }
        public ICollection<Description> Descriptions { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
