using Isopoh.Cryptography.Argon2;
using StorageStation.Domain.Locations;
using StorageStation.Domain.Products;
using StorageStation.Domain.Users;

namespace StorageStation.Infrastructure.Common.DbContext;

public static class Seed
{
    public static async Task PopulateDbAsync(StorageStationDbContext dbContext)
    {
        if (!dbContext.Households.Any())
        {
            dbContext.Households.AddRange(new List<Household>
            {
                new("The Scott's")
            });
        }

        await dbContext.SaveChangesAsync();

        var scottHouseholdId = dbContext.Households.First().Id;
        if (!dbContext.Locations.Any())
        {
            dbContext.Locations.AddRange(new List<Location>
            {
                new("Home", scottHouseholdId), new Location("Basement", scottHouseholdId)
            });
        }

        if (!dbContext.Users.Any())
        {
            dbContext.Users.AddRange(new List<User>()
            {
                new("mikescott", "mikescott@dundermifflin.com", "Michael Scott", Argon2.Hash("mikescott")),
                new("jimhalpert", "jimhalpert@dundermifflin.com", "James Halpert", Argon2.Hash("jimhalpert"))
            });
        }

        if (!dbContext.Categories.Any())
        {
            foreach (var categoryType in Enum.GetValues(typeof(CategoryType)).Cast<CategoryType>())
            {
                dbContext.Categories.Add(new Category((int) categoryType, categoryType.ToString(), scottHouseholdId));
            }
        }

        if (!dbContext.Products.Any())
        {
            dbContext.Products.AddRange(new List<Product>
            {
                new("Beans", (int) CategoryType.Vegetables, scottHouseholdId),
                new("Pickles", (int) CategoryType.PickedFood, scottHouseholdId),
                new("Wine", (int) CategoryType.Alcohol, scottHouseholdId),
                new("Chicken", (int) CategoryType.Meat, scottHouseholdId),
                new("Pepper", (int) CategoryType.Vegetables, scottHouseholdId),
                new("Rakiya", (int) CategoryType.Alcohol, scottHouseholdId),
                new("Tomatoes", (int) CategoryType.CannedFood, scottHouseholdId),
            });
        }

        await dbContext.SaveChangesAsync();
    }
}