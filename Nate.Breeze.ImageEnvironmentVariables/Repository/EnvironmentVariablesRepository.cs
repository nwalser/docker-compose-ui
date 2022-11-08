using Nate.Breeze.ImageEnvironmentVariables.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.ImageEnvironmentVariables.Repository;

public class EnvironmentVariablesRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string EnvironmentVariablesFileName = "image-environment_variables.json";
    
    public async Task<List<EnvironmentVariable>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var portsPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{EnvironmentVariablesFileName}";
        var portsContent = await File.ReadAllTextAsync(portsPath);
        
        var ports = JsonConvert.DeserializeObject<List<EnvironmentVariable>>(portsContent);

        if (ports == default)
            throw new Exception();
        
        return ports;
    }
}