namespace StorageStation.Domain.Models
{
    public sealed class ShoppingList
    {
        public ShoppingList()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int CreatedByUserId { get; set; }

        public User CreatedByUser { get; set; } = null!;
        public ICollection<Item> Items { get; set; }
    }
}
