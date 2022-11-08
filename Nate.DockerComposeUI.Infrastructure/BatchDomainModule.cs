#region

using Autofac;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Nate.DockerComposeUI.Domain.Model.Entities;
using Nate.DockerComposeUI.Domain.Stores;
using Nate.DockerComposeUI.Infrastructure.Seeder;
using Nate.DockerComposeUI.Infrastructure.Stores;

#endregion

namespace Nate.DockerComposeUI.Infrastructure;

public class BatchDomainModule : Module
{
    public string MongoDbConnectionString { get; set; } = string.Empty;
    public string BatchDatabaseName { get; set; } = string.Empty;
    public string BatchCollectionName { get; set; } = string.Empty;


    protected override void Load(ContainerBuilder builder)
    {
        // PACKAGES
        // mongo db
        var client = new MongoClient(MongoDbConnectionString);
        var database = client.GetDatabase(BatchDatabaseName);
        var collection = database.GetCollection<ImageEntity>(BatchCollectionName);

        builder.Register(c => collection);

        // SEEDER
        builder.RegisterType<ImageCollectionIndexSeeder>().As<IHostedService>().SingleInstance();

        // STORES
        // repository
        builder.RegisterType<ImageRepository>().As<IImageRepository>();
        // query
        builder.RegisterType<ImageQuery>().As<IImageQuery>();

        // HANDLERS
        // register all mediatr handlers from assembly
        //builder.RegisterMediatR(typeof(CreateBatchCommandHandler).Assembly);
    }
}