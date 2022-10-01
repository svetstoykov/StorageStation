namespace StorageStation.Domain.Models
{
    public class StoredItem
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public int QtyInGrams { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }

        public virtual Location Location { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
