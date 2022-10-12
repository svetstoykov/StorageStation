using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StorageStation.Application.Common;
using StorageStation.Application.Users.Abstractions;
using StorageStation.Domain.Common;
using StorageStation.Domain.Users;

namespace StorageStation.Infrastructure.Users.Tokens;

public class TokensService : ITokensService
{
    private readonly IConfiguration _configuration;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

    public TokensService(IConfiguration configuration)
    {
        this._configuration = configuration;
        this._jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new(StorageStationClaimTypes.Username, user.Username),
            new(StorageStationClaimTypes.UserIdentifier, user.Id.ToString()),
            new(StorageStationClaimTypes.HouseholdIdentifier, user.HouseholdId.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration[GlobalConstants.TokenKey]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = credentials
        };

        var token = this._jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

        return this._jwtSecurityTokenHandler.WriteToken(token);
    }
}