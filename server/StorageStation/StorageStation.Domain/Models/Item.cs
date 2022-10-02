using StorageStation.Domain.Common;

namespace StorageStation.Domain.Models
{
    public sealed class Item : DomainEntity
    {
        private Item() { }
        
        public Item(Product product, int qty, int qtyInGrams)
        {
            this.Product = product;
            this.Qty = qty;
            this.QtyInGrams = qtyInGrams;
        }
        
        public int ShoppingListId { get; private set; }
        public int ProductId { get; private set; }
        public int Qty { get; private set; }
        public int QtyInGrams { get; private set; }

        public Product Product { get; private set; }
        public ShoppingList ShoppingList { get; private set; }
    }
}
