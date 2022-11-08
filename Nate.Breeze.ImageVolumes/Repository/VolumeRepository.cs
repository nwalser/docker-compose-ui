using Nate.Breeze.ImageVolumes.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.ImageVolumes.Repository;

public class VolumeRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string SecretsFileName = "image-volumes.json";
    
    public async Task<List<Volume>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var portsPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{SecretsFileName}";
        var portsContent = await File.ReadAllTextAsync(portsPath);
        
        var ports = JsonConvert.DeserializeObject<List<Volume>>(portsContent);

        if (ports == default)
            throw new Exception();
        
        return ports;
    }
}