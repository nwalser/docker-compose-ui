#region

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Nate.DockerComposeUI.Domain.Model.Entities;
using Nate.DockerComposeUI.Domain.Stores;

#endregion

namespace Nate.DockerComposeUI.Infrastructure.Stores;

public class ImageQuery : IImageQuery
{
    private readonly IMongoCollection<ImageEntity> _collection;

    public ImageQuery(IMongoCollection<ImageEntity> collection)
    {
        _collection = collection;
    }

    public async Task<ImageEntity> GetAsync(Guid id)
    {
        var filter = Builders<ImageEntity>.Filter.Eq(e => e.Id, id);
        return await _collection.Find(filter).FirstAsync();
    }
}