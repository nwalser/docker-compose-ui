#region

using MongoDB.Driver;
using Nate.DockerComposeUI.Domain.Model.Aggregates;
using Nate.DockerComposeUI.Domain.Model.Entities;
using Nate.DockerComposeUI.Domain.Stores;
using Nate.DockerComposeUI.Infrastructure.MongoDb;

#endregion

namespace Nate.DockerComposeUI.Infrastructure.Stores;

public class ImageRepository : MongoDbRepository<ImageAggregate, ImageEntity>, IImageRepository
{
    public ImageRepository(IMongoCollection<ImageEntity> collection)
    {
        Collection = collection;
    }

    protected override IMongoCollection<ImageEntity> Collection { get; }

    protected override ImageEntity AggregateToEntity(ImageAggregate aggregate)
    {
        return aggregate.ToEntity();
    }

    protected override ImageAggregate EntityToAggregate(ImageEntity entity)
    {
        return new ImageAggregate(entity);
    }
}