#region

using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Nate.DockerComposeUI.Domain.Model.Entities;

#endregion

namespace Nate.DockerComposeUI.Infrastructure.Seeder;

public class ImageCollectionIndexSeeder : IHostedService
{
    private readonly IMongoCollection<ImageEntity> _collection;

    public ImageCollectionIndexSeeder(IMongoCollection<ImageEntity> collection)
    {
        _collection = collection;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Seed(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task Seed(CancellationToken cancellationToken)
    {
        
        // // batch id index
        // {
        //     var index = Builders<ImageEntity>.IndexKeys.Ascending(b => b.Id);
        //     var indexOptions = new CreateIndexOptions<ImageEntity>();
        //
        //     var indexModel = new CreateIndexModel<ImageEntity>(index, indexOptions);
        //
        //     await _collection.Indexes.CreateOneAsync(indexModel, cancellationToken: cancellationToken);
        // }
        //
        // // fisba batch id index
        // {
        //     var index = Builders<ImageEntity>.IndexKeys.Ascending(b => b.FisbaBatchId);
        //     var indexOptions = new CreateIndexOptions<ImageEntity>
        //     {
        //         Unique = true
        //     };
        //
        //     var indexModel = new CreateIndexModel<ImageEntity>(index, indexOptions);
        //
        //     await _collection.Indexes.CreateOneAsync(indexModel, cancellationToken: cancellationToken);
        // }
    }
}