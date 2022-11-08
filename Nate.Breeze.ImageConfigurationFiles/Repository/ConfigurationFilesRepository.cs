using Nate.Breeze.ImageConfigurationFiles.Model;
using Newtonsoft.Json;

namespace Nate.Breeze.ImageConfigurationFiles.Repository;

public class ConfigurationFilesRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string FileName = "image-configuration_files.json";
    
    public async Task<List<ConfigurationFile>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var path = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/{FileName}";
        var content = await File.ReadAllTextAsync(path);
        
        var configurationFiles = JsonConvert.DeserializeObject<List<ConfigurationFile>>(content);

        if (configurationFiles == default)
            throw new Exception();
        
        return configurationFiles;
    }
}