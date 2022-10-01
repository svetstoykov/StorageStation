namespace StorageStation.Domain.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Qty { get; set; }
        public int QtyInGrams { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
        public virtual Description NameNavigation { get; set; } = null!;
    }
}
