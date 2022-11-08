using Nate.Breeze.ImageDeployments.Model;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nate.Breeze.ImageDeployments.Repository;

public class DeploymentRepository
{
    private const string BasePath = @"C:\Users\Nathaniel Walser\Documents\Respositories\docker-compose-ui\images";
    private const string ConfigFileName = "config.json";
    private const string DeploymentFileName = "deployment.yml";
    
    private IDeserializer Deserializer { get; set; }
    
    
    public DeploymentRepository()
    {
        Deserializer = new DeserializerBuilder()
            .WithNamingConvention(UnderscoredNamingConvention.Instance)
            .Build();
    }
    
    
    public async Task<List<Deployment>> Load(string imageOrganisation, string imageNamespace, string imageTag)
    {
        var deploymentPath = $"{BasePath}/{imageOrganisation}/{imageNamespace}/{imageTag}/deployments";
        var deploymentDirectories = Directory.GetDirectories(deploymentPath);

        var tasks = deploymentDirectories.Select(async deploymentDirectory =>
        {
            var deploymentJson = await File.ReadAllTextAsync(deploymentDirectory + "/" + ConfigFileName);
            var deploymentYml = await File.ReadAllTextAsync(deploymentDirectory + "/" + DeploymentFileName);

            var deployment = JsonConvert.DeserializeObject<Breeze.ImageDeployments.Model.Deployment>(deploymentJson);

            if (deployment == default)
                throw new Exception();
            
            deployment.DockerComposeYml = deploymentYml;
            
            return deployment;
        }).ToList();

        await Task.WhenAll(tasks);

        var deployments = tasks.Select(d => d.Result).ToList();
        
        return deployments;
    }
}