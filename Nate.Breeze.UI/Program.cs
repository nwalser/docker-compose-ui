using System.Globalization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using MudBlazor.Services;
using Nate.Breeze.Image.Repository;
using Nate.Breeze.ImageConfigurationFiles.Repository;
using Nate.Breeze.ImageDeployments.Repository;
using Nate.Breeze.ImageDescription.Repository;
using Nate.Breeze.ImageEnvironmentVariables.Repository;
using Nate.Breeze.ImagePorts.Repository;
using Nate.Breeze.ImageSecrets.Repository;
using Nate.Breeze.ImageVolumes.Repository;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// configure host
builder.Host.UseSerilog();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
    b.RegisterType<ImagesRepository>();
    b.RegisterType<ConfigurationFilesRepository>();
    b.RegisterType<DeploymentRepository>();
    b.RegisterType<DescriptionRepository>();
    b.RegisterType<EnvironmentVariablesRepository>();
    b.RegisterType<PortsRepository>();
    b.RegisterType<SecretsRepository>();
    b.RegisterType<VolumeRepository>();
});

// configure webhost
builder.WebHost.UseSentry();
builder.WebHost.UseStaticWebAssets();

// configure services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();


var app = builder.Build();

// configure http pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();