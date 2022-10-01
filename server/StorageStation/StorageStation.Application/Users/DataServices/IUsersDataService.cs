using StorageStation.Application.Common.DataServices;
using StorageStation.Domain.Models;

namespace StorageStation.Application.Users.DataServices;

public interface IUsersDataService : IEntityDataService<User>
{
    Task<User?> GetByUsernameAsync(string username);
}