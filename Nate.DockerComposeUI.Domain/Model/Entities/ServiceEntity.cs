using Nate.DockerComposeUI.Domain.Model.ValueObjects;

namespace Nate.DockerComposeUI.Domain.Model.Entities;

public class ServiceEntity
{
    public string ImageName { get; set; }
    
    public List<(string name, string value)> EnvironmentVariables { get; set; } = null!; 
    public List<(int containerPort, int hostPort)> PortBinding { get; set; } = null!;
    public List<(string volumeName, string containerPath)> VolumeMount { get; set; } = null!;
    public List<(string configName, string containerPath)> ConfigMount { get; set; } = null!;
    public List<(string secretName, string secretContainerName)> SecretMount { get; set; } = null!;
}