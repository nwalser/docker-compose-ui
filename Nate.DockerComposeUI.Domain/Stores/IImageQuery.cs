#region

#endregion

using Nate.DockerComposeUI.Domain.Core.Query;
using Nate.DockerComposeUI.Domain.Model.Entities;

namespace Nate.DockerComposeUI.Domain.Stores;

public interface IImageQuery : IQuery<ImageEntity, Guid>
{
    
}