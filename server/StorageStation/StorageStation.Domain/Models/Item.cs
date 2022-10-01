namespace StorageStation.Domain.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public string Product { get; set; } = null!;
        public int Qty { get; set; }
        public int QtyInGrams { get; set; }

        public virtual ShoppingList ShoppingList { get; set; } = null!;
    }
}
