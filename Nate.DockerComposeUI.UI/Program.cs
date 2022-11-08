using System.Globalization;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Serilog;
using MudBlazor.Services;
using Nate.DockerComposeUI.Deployment.Repository;
using Nate.DockerComposeUI.Image.Repository;

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
    b.RegisterType<ImageRepository>().As<IImageRepository>();
    b.RegisterType<DeploymentRepository>().As<IDeploymentRepository>();
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