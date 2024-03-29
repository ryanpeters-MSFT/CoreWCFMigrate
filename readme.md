# WCF-to-CoreWCF: Side-by-side

With the creation of .NET "core", while WCF service support was (initially) unsupported on the server side, client support has always been there, leveraging various `System.ServiceModel.***` packages that mirror the same type definitions found in .NET Framework. 

## Binding Configuration

- **Framework** - Typically configured within the `<system.ServiceModel />` section of web.config, along with endpoint behavior and service behavior definition. Configuration can also be made via C# code.
- **CoreWCF** - Solely configured via C# code in the .NET pipeline via `WebApplicationExtensions.UseServiceModel(...)` and other middleware extensions provided by CoreWCF.

## Endpoint Implementation

- **Framework** - IService.cs contract and Service.svc.cs implementation for Service.svc on file system.
- **CoreWCF** - Path Service.svc is defined via `IServiceBuilder.AddServiceEndpoint<TService, TContract>` and `IServiceBuilder.AddService<TService>`.

## Dependency Injection

- **Framework** - Use of custom `ServiceHostFactory` and `ServiceHost` to add `IServiceBehavior` with custom instance provider.
- **CoreWCF** - Uses native `IServiceCollection` and `IServiceProvider` as part of middleware pipeline.
  

## Client Code Generation

- **Framework** - *Add Service Reference...* (in VS) or via `svcutil.exe`
- **CoreWCF** - *Add* and *Service Reference...* (in VS) or via [`dotnet-svcutil`