using Nate.DockerComposeUI.Domain.Core.Model;
using Nate.DockerComposeUI.Domain.Model.ValueObjects;

namespace Nate.DockerComposeUI.Domain.Model.Entities;

public class ImageEntity : IEntity
{
    public Guid Id { get; }

    public ImageId ImageId { get; set; } = null!;
    public ImageDescription ImageDescription { get; set; } = null!;
    public CreatedDate CreatedDate { get; set; } = null!;
    
    public List<Port> Ports { get; set; } = new();
    public List<EnvironmentVariable> EnvironmentVariables { get; set; } = new();
    public List<ConfigurationFile> ConfigurationFiles { get; set; } = new();
    public List<Secret> Secrets { get; set; } = new();
    public List<Volume> Volumes { get; set; } = new();

    public List<ImageId> RelatedImages { get; set; } = new();
}