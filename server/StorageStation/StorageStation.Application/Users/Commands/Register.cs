using Isopoh.Cryptography.Argon2;
using MediatR;
using StorageStation.Application.Common.Result;
using StorageStation.Application.Users.Abstractions;
using StorageStation.Application.Users.DataServices;
using StorageStation.Domain.Models;

namespace StorageStation.Application.Users.Commands;

public class Register
{
    public class Command : IRequest<Result<string>>
    {
        public Command(string fullName, string username, string password, string email)
        {
            this.FullName = fullName;
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
        
        public string FullName { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
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
            var passwordHash = Argon2.Hash(request.Password);

            var newUser = new User(request.Username, request.Email, request.FullName, passwordHash);

            this._usersDataService.Create(newUser);

            await this._usersDataService.SaveChangesAsync(cancellationToken);

            return Result<string>.Success(this._tokensService.GenerateToken(newUser));
        }
    }
}