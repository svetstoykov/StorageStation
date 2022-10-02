using StorageStation.Domain.Common;

namespace StorageStation.Application.Common.DataServices;

public interface IEntityDataService<TDomainEntity>
    where TDomainEntity : DomainEntity
{
    IQueryable<TDomainEntity> GetAsQueryable();
    Task SaveChangesAsync(CancellationToken token = default);
    Task<TDomainEntity> GetByIdAsync(int id, CancellationToken token = default);
    void Create(TDomainEntity activity);
    void Update(TDomainEntity activity);
    void Remove(TDomainEntity activity);
}