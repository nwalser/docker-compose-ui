// See https://aka.ms/new-console-template for more information

using Nate.Breeze.ImageDeployments.Model;
using Newtonsoft.Json;


var deployment = new Deployment()
{
    Name = "Small Deployment",
    Description = "Some Description",

    DockerComposeYml = "dfsfdsf"
};


var yaml = JsonConvert.SerializeObject(deployment);
System.Console.WriteLine(yaml);