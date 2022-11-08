#region

#endregion

using Nate.DockerComposeUI.Domain.Core.Repository;
using Nate.DockerComposeUI.Domain.Model.Aggregates;

namespace Nate.DockerComposeUI.Domain.Stores;

public interface IImageRepository : IRepository<ImageAggregate, Guid>
{
}