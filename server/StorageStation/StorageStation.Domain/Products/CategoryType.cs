using System.ComponentModel;

namespace StorageStation.Domain.Products;

public enum CategoryType
{
    [Description("Canned Food")] CannedFood = 1,
    [Description("Meat")] Meat = 2,
    [Description("Vegetables")] Vegetables = 3,
    [Description("Picked Food")] PickedFood = 4,
    [Description("Alcohol")] Alcohol = 5
}