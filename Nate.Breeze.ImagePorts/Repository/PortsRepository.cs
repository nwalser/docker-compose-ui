using Nate.Breeze.ImagePorts.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.ImagePorts.Repository;

public class PortsRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string PortsFileName = "image-ports.json";
    
    public async Task<List<Port>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var portsPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{PortsFileName}";
        var portsContent = await File.ReadAllTextAsync(portsPath);
        
        var ports = JsonConvert.DeserializeObject<List<Port>>(portsContent);

        if (ports == default)
            throw new Exception();
        
        return ports;
    }
}