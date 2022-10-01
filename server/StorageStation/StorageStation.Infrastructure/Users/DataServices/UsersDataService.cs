using Microsoft.EntityFrameworkCore;
using StorageStation.Application.Users.DataServices;
using StorageStation.Domain.Models;
using StorageStation.Infrastructure.Common.DataServices;
using StorageStation.Infrastructure.Common.DbContext;

namespace StorageStation.Infrastructure.Users.DataServices;

public class UsersDataService : EntityDataService<User>, IUsersDataService
{
    public UsersDataService(StorageStationDbContext dataContext) : base(dataContext)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
        => await this.DataSet.FirstOrDefaultAsync(u => u.Username == username);
}