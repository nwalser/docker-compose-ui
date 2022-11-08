using Nate.DockerComposeUI.Image.Model;

namespace Nate.DockerComposeUI.Image.Repository;

public class ImageRepository : IImageRepository
{
    public Task<ImageLayout> Load(string imageNamespace, string imageTag)
    {
        throw new NotImplementedException();
    }
}