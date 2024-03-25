var builder = WebApplication.CreateBuilder();

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelWebServices(); // required for Web HTTP endpoint
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<Service>();

    serviceBuilder.AddServiceEndpoint<Service, IService>(new BasicHttpBinding(/*BasicHttpSecurityMode.Transport*/), "/Service.svc");
    serviceBuilder.AddServiceWebEndpoint<Service, IService>("json", config => config.DefaultOutgoingResponseFormat = CoreWCF.Web.WebMessageFormat.Json);

    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpsGetEnabled = true;
});

app.Run();
