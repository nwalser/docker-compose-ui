namespace Nate.DockerComposeUI.Image.Model;

public class ImageLayout
{
    public string Namespace { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    
    public List<Port> Ports { get; set; } = new();
    public List<EnvironmentVariable> EnvironmentVariables { get; set; } = new();
    public List<ConfigurationFile> ConfigurationFiles { get; set; } = new();
    public List<Secret> Secrets { get; set; } = new();
    public List<Volume> Volumes { get; set; } = new();
}