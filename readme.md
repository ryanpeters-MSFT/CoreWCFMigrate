# WCF-to-CoreWCF: Side-by-side

## Endpoint Definition

- **Framework** - IService.cs contract and Service.svc.cs implementation for Service.svc on file system
- **CoreWCF** - Path Service.svc is defined via `IServiceBuilder.AddServiceEndpoint<TService, TContract>` and `IServiceBuilder.AddService<TService>`

