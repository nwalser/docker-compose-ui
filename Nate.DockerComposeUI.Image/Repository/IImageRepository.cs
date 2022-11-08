using Nate.DockerComposeUI.Image.Model;

namespace Nate.DockerComposeUI.Image.Repository;

public interface IImageRepository
{
    public Task<ImageLayout> Load(string imageNamespace, string imageTag);
}