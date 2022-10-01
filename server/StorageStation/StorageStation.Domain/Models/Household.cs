namespace StorageStation.Domain.Models
{
    public sealed class Household
    {
        public Household()
        {
            Categories = new HashSet<Category>();
            Locations = new HashSet<Location>();
            Products = new HashSet<Product>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Category> Categories { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
