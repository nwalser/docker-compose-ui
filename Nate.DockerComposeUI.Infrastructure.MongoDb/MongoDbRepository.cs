#region

using MongoDB.Driver;
using Nate.DockerComposeUI.Domain.Core.Model;

#endregion

namespace Nate.DockerComposeUI.Infrastructure.MongoDb;

public abstract class MongoDbRepository<TAggregate, TEntity> where TEntity : IEntity
{
    protected abstract IMongoCollection<TEntity> Collection { get; }
    protected abstract TEntity AggregateToEntity(TAggregate aggregate);
    protected abstract TAggregate EntityToAggregate(TEntity entity);


    public async Task<TAggregate> GetAsync(Guid id)
    {
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, id);
        var entity = await Collection.Find(filter).FirstAsync();
        var aggregate = EntityToAggregate(entity);

        return aggregate;
    }

    public async Task AddAsync(TAggregate aggregate)
    {
        var entity = AggregateToEntity(aggregate);
        await Collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(TAggregate aggregate)
    {
        var entity = AggregateToEntity(aggregate);
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
        await Collection.ReplaceOneAsync(filter, entity);
    }

    public async Task DeleteAsync(TAggregate aggregate)
    {
        var entity = AggregateToEntity(aggregate);
        var filter = Builders<TEntity>.Filter.Eq(e => e.Id, entity.Id);
        await Collection.DeleteOneAsync(filter);
    }
}