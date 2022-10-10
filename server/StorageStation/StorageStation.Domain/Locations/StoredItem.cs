using StorageStation.Domain.Common;
using StorageStation.Domain.Products;

namespace StorageStation.Domain.Locations;

public sealed class StoredItem : DomainEntity
{
    private StoredItem() { }
        
    public StoredItem(int productId, int locationId, int qty, int qtyInGrams)
    {
        this.ProductId = productId;
        this.LocationId = locationId;
        this.Qty = qty;
        this.QtyInGrams = qtyInGrams;
    }

    public int Qty { get; private set; }
    public int QtyInGrams { get; private set; }
    public int LocationId { get; private set; }
    public int ProductId { get; private set; }

    public Location Location { get; private set; } 
    public Product Product { get; private set; } 
}