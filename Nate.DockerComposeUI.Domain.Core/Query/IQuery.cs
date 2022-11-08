namespace Nate.DockerComposeUI.Domain.Core.Query;

public interface IQuery<TType, in TKey>
{
    public Task<TType> GetAsync(TKey id);
}