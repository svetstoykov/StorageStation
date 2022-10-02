
using StorageStation.Domain.Models;

namespace StorageStation.Application.Users.Abstractions;

public interface ITokensService
{
    public string GenerateToken(User user);
}