# WCF-to-CoreWCF: Side-by-side

With the creation of .NET "core", while WCF service support was (initially) unsupported on the server side, client support has always been there, leveraging various `System.ServiceModel.***` packages that mirror the same type definitions found in .NET Framework. 

## Comparison

| **Aspect** | **WCF on .NET Framework** | **CoreWCF** |
|-|-|-|
| **Platform Support** | Runs on the **.NET Framework** (Windows-only). | Runs on **modern versions of .NET** (including .NET 6+). |
| **Protocols**             | Supports SOAP, REST, TCP, Named Pipes, MSMQ, HTTP         | Supports SOAP, REST, TCP, Named Pipes, HTTP                   |
| **Hosting**               | IIS, Self-hosting, Windows Services                        | Self-hosting, Docker containers, Azure Functions               |
| **Configuration**         | XML-based configuration                                    | XML-based or code-based configuration                         |
| **Community-Driven** | Developed by Microsoft, but **not actively maintained**. | A **community-driven .NET Foundation project** with Microsoft providing product support. |
| **Functionality** | Supports **many common WCF scenarios**, but **not all WCF functionality**. | Provides a compatible implementation of **SOAP, NetTCP, and WSDL**. |
| **Recommended Use** | **Legacy applications** with heavy WCF dependencies. | Useful for projects with existing WCF dependencies that need to move to **.NET 6+**. |
| **Service Host** | Hosted using **Windows services**, IIS, or custom hosts. | Uses **ASP.NET Core** as the service host.                                                                     |
| **Microsoft Support** | Supported by Microsoft. | Although not a Microsoft-owned project, Microsoft provides support for CoreWCF. |

Keep in mind that while CoreWCF is a great option for modernizing existing WCF applications, newer technologies like **gRPC** and **ASP.NET WebAPI** are recommended for new development.

## Binding Configuration

- **Framework** - Typically configured within the `<system.ServiceModel />` section of web.config, along with endpoint behavior and service behavior definition. Configuration can also be made via C# code.
- **CoreWCF** - Solely configured via C# code in the .NET pipeline via `WebApplicationExtensions.UseServiceModel(...)` and other middleware extensions provided by CoreWCF. 

**NOTE** - If legacy configuration is required in CoreWCF, the [CoreWCF.ConfigurationManager](https://www.nuget.org/packages/CoreWCF.ConfigurationManager) package is available to provide *limited* support for most aspects of config-based setup of services, endpoints, and basic binding configurations.

## Endpoint Implementation

- **Framework** - IService.cs contract and Service.svc.cs implementation for Service.svc on file system.
- **CoreWCF** - Path Service.svc is defined via `IServiceBuilder.AddServiceEndpoint<TService, TContract>` and `IServiceBuilder.AddService<TService>`.

## Dependency Injection

- **Framework** - Use of custom `ServiceHostFactory` and `ServiceHost` to add `IServiceBehavior` with custom instance provider.
- **CoreWCF** - Uses native `IServiceCollection` and `IServiceProvider` as part of middleware pipeline.

## Client Code Generation

- **Framework** - *Add Service Reference...* (in VS) or via `svcutil.exe`
- **CoreWCF** - *Add* and *Service Reference...* (in VS) or via `dotnet-svcutil`

## Links

- [**Bring WCF apps to the latest .NET with CoreWCF and Upgrade Assistant**](https://devblogs.microsoft.com/dotnet/migration-wcf-to-corewcf-upgrade-assistant/)
- [**Upgrade a WCF Server-side Project to use CoreWCF on .NET 6**](https://learn.microsoft.com/en-us/dotnet/core/porting/upgrade-assistant-wcf)
- [**CoreWCF 1.4.0 Preview release**](https://corewcf.github.io/blog/2023/04/17/corewcf-1_4_0_preview)