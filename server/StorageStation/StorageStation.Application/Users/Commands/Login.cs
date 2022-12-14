using Isopoh.Cryptography.Argon2;
using MediatR;
using StorageStation.Application.Common.Result;
using StorageStation.Application.Users.Abstractions;
using StorageStation.Application.Users.DataServices;

namespace StorageStation.Application.Users.Commands;

public class Login
{
    public class Command : IRequest<Result<string>>
    {
        public Command(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }

    public class Handler : IRequestHandler<Command, Result<string>>
    {
        private readonly IUsersDataService _usersDataService;
        private readonly ITokensService _tokensService;

        public Handler(IUsersDataService usersDataService, ITokensService tokensService)
        {
            this._usersDataService = usersDataService;
            this._tokensService = tokensService;
        }

        public async Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await this._usersDataService.GetByUsernameAsync(request.Username);
            if (user == null)
            {
                return Result<string>.Unauthorized(
                    "Invalid username");
            }

            return Argon2.Verify(user.PasswordHash, request.Password)
                ? Result<string>.Success(this._tokensService.GenerateToken(user))
                : Result<string>.Unauthorized("Invalid Password");
        }
    }
}