using Nate.Breeze.ImageSecrets.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.ImageSecrets.Repository;

public class SecretsRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string SecretsFileName = "image-secrets.json";
    
    public async Task<List<Secret>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var portsPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{SecretsFileName}";
        var portsContent = await File.ReadAllTextAsync(portsPath);
        
        var ports = JsonConvert.DeserializeObject<List<Secret>>(portsContent);

        if (ports == default)
            throw new Exception();
        
        return ports;
    }
}