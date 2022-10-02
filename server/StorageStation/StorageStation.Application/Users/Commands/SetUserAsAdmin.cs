using MediatR;
using StorageStation.Application.Common.Result;
using StorageStation.Application.Users.DataServices;

namespace StorageStation.Application.Users.Commands;

public class SetUserAsAdmin
{
    public class Command : IRequest<Result<Unit>>
    {
        public Command(int userIdToSetAsAdmin, int userIdMakingRequest)
        {
            this.UserIdToSetAsAdmin = userIdToSetAsAdmin;
            this.UserIdMakingRequest = userIdMakingRequest;
        }

        public int UserIdToSetAsAdmin { get; }
        
        public int UserIdMakingRequest { get; }
    }
    
    public class Handler: IRequestHandler<Command, Result<Unit>>
    {
        private readonly IUsersDataService _usersDataService;

        public Handler(IUsersDataService usersDataService)
        {
            this._usersDataService = usersDataService;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userMakingRequest = await this._usersDataService
                .GetByIdAsync(request.UserIdMakingRequest, cancellationToken);

            if (!userMakingRequest.IsAdmin)
            {
                return Result<Unit>.Failure(
                    "You do not have permissions. Please contact your client admin.");
            }

            var userToSetAsAdmin = await this._usersDataService
                .GetByIdAsync(request.UserIdToSetAsAdmin, cancellationToken);

            userToSetAsAdmin.UpdateUserAdminStatus(isAdmin: true);

            await this._usersDataService.SaveChangesAsync(cancellationToken);
            
            return Result<Unit>.Success(Unit.Value);
        }
    }
}