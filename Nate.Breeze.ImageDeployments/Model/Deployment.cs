namespace Nate.Breeze.ImageDeployments.Model;

public class Deployment
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public string DockerComposeYml { get; set; } = string.Empty;
}