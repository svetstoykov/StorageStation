﻿namespace StorageStation.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public int QtyInGrams { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ShoppingList ShoppingList { get; set; } = null!;
    }
}
