using Nate.Breeze.ImageDescription.Model;

namespace Nate.Breeze.ImageDescription.Repository;

public class DescriptionRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    
    
    public async Task<Description> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var imagePath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}";
        var filePath = $"{imagePath}/image-description.md";

        var imageDescription = new Description(await File.ReadAllTextAsync(filePath));

        return imageDescription;
    }
}