
using Nate.Breeze.Images.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.Images.Repository;

public class ImagesRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string PortsFileName = "image.json";
    
    public async Task<List<Image>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var portsPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{PortsFileName}";
        var portsContent = await File.ReadAllTextAsync(portsPath);
        
        var ports = JsonConvert.DeserializeObject<List<Image>>(portsContent);

        if (ports == default)
            throw new Exception();
        
        return ports;
    }
}