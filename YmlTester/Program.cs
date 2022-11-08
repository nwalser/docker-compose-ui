// See https://aka.ms/new-console-template for more information

using Nate.DockerComposeUI.Deployment.Model;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


var deployment = new Deployment()
{
    Name = "Small Deployment",
    Description = "Some Description",

    DockerComposeYml = "dfsfdsf"
};


var yaml = JsonConvert.SerializeObject(deployment);
System.Console.WriteLine(yaml);