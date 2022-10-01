namespace StorageStation.Application.Common.DataServices
{
    public interface IEntityDataService<TDomainEntity>
        where TDomainEntity : class, new()
    {
        public IQueryable<TDomainEntity> GetAsQueryable();

        public void Create(TDomainEntity activity);

        public void Update(TDomainEntity activity);

        public void Remove(TDomainEntity activity);

        Task SaveChangesAsync(CancellationToken token = default, string? errorToShow = null);
    }
}
