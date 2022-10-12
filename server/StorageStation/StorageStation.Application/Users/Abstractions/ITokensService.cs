
using StorageStation.Domain.Users;

namespace StorageStation.Application.Users.Abstractions;

public interface ITokensService
{
    public string GenerateToken(User user);
}