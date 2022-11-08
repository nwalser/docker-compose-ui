namespace Nate.DockerComposeUI.Domain.Core.Repository;

public interface IRepository<TType, in TKey>
    where TType : class
{
    public Task<TType> GetAsync(TKey id);

    public Task AddAsync(TType aggregate);

    public Task UpdateAsync(TType aggregate);

    public Task DeleteAsync(TType aggregate);
}