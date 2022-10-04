using Microsoft.EntityFrameworkCore;
using StorageStation.Application.Common;
using StorageStation.Application.Common.DataServices;
using StorageStation.Application.Common.ErrorHandling;
using StorageStation.Domain.Common;
using StorageStation.Infrastructure.Common.DbContext;

namespace StorageStation.Infrastructure.Common.DataServices;

public class EntityDataService<TDomainEntity> : IEntityDataService<TDomainEntity>
    where TDomainEntity : DomainEntity
{
    protected readonly StorageStationDbContext DataContext;
    protected readonly DbSet<TDomainEntity> DataSet;

    public EntityDataService(StorageStationDbContext dataContext)
    {
        this.DataContext = dataContext;
        this.DataSet = dataContext.Set<TDomainEntity>();
    }

    public IQueryable<TDomainEntity> GetAsQueryable()
        => this.DataSet;

    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        if (await this.DataContext.SaveChangesAsync(token) > 0)
            return;

        throw new AppException(GlobalErrorMessages.UnableToSaveChanges);
    }

    public async Task<TDomainEntity> GetByIdAsync(int id, CancellationToken token = default)
    {
        var user = await this.DataSet
            .FirstOrDefaultAsync(entity => entity.Id == id, token);

        if (user is null)
        {
            throw new AppException(GlobalErrorMessages.UserDoesNotExist);
        }

        return user;
    }
        
    public void Create(TDomainEntity entity)
        => this.DataSet.Add(entity);

    public void Update(TDomainEntity entity)
        => this.DataSet.Update(entity);

    public void Remove(TDomainEntity entity)
        => this.DataSet.Remove(entity);
}