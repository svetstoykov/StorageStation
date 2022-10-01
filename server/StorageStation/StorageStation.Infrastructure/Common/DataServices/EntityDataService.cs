using Microsoft.EntityFrameworkCore;
using StorageStation.Application.Common.DataServices;
using StorageStation.Application.Common.ErrorHandling;
using StorageStation.Domain.Common;
using StorageStation.Infrastructure.Common.DbContext;

namespace StorageStation.Infrastructure.Common.DataServices
{
    public class EntityDataService<TDomainEntity> : IEntityDataService<TDomainEntity>
        where TDomainEntity : class, new()
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

        public async Task SaveChangesAsync(CancellationToken token = default, string? errorToShow = null)
        {
            if (await this.DataContext.SaveChangesAsync(token) > 0)
                return;

            throw new AppException(errorToShow ?? GlobalConstants.UnableToSaveChanges);
        }

        public void Create(TDomainEntity entity)
            => this.DataSet.Add(entity);

        public void Update(TDomainEntity entity)
            => this.DataSet.Update(entity);

        public void Remove(TDomainEntity entity)
            => this.DataSet.Remove(entity);
    }
}
