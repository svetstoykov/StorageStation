using MediatR;
using StorageStation.Application.Common.Result;

namespace StorageStation.Application.Users.Commands;

public class Register
{
    public class Command : IRequest<Result<string>>
    {
        public Command(string fullName, string username, string password, string email, int householdId)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Email = email;
            HouseholdId = householdId;
        }
        
        public string FullName { get; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; }
        public int HouseholdId { get; }
    }

    public class Handler : IRequestHandler<Command, Result<string>>
    {
        public Task<Result<string>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}