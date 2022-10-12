using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StorageStation.Infrastructure.Common.DbContext;

namespace StorageStation.StartUp.Helpers;

public static class DataSeedHelper
{
    public static async void GetRequiredServiceAndSeedDataAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var services = scope.ServiceProvider;
        var dboContext = services.GetRequiredService<StorageStationDbContext>();

        try
        {
            await Seed.PopulateDbAsync(dboContext);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Migration failed. Message: '{ex.Message}'");
        }
    }
}