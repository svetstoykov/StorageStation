namespace StorageStation.Infrastructure.Users.Tokens;

public static class StorageStationClaimTypes
{
    public static string Username = typeof(StorageStationClaimTypes).Namespace + nameof(Username);
    
    public static string UserIdentifier = typeof(StorageStationClaimTypes).Namespace + nameof(UserIdentifier);

    public static string HouseholdIdentifier = typeof(StorageStationClaimTypes).Namespace + nameof(HouseholdIdentifier);
}
