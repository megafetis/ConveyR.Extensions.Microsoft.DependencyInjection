# ConveyR.Extensions.Microsoft.DependencyInjection
=======
[![NuGet](https://img.shields.io/nuget/dt/ConveyR.Extensions.Microsoft.DependencyInjection.svg)](https://www.nuget.org/packages/ConveyR.Extensions.Microsoft.DependencyInjection/) 
[![NuGet](https://img.shields.io/nuget/vpre/ConveyR.Extensions.Microsoft.DependencyInjection.svg)](https://www.nuget.org/packages/ConveyR.Extensions.Microsoft.DependencyInjection/)

ConveyR extensions for Microsoft.Extensions.DependencyInjection DI

DI extensions for [ConveyR](https://github.com/megafetis/ConveyR).

##### Basic usage

```cs 

var services = new ServiceCollection();
services.AddConveyR(); // by default scan entry point assembly
//or services.AddConveyR(Assembly1,Assembly2,...);
var provider = services.BuildServiceProvider();

```
##### Custom
```cs

var services = new ServiceCollection();
services.AddConveyR(new []{Assembly1,Assembly2},conf=>conf.AsSingleton().Unsing<CustomConveyor>());
var provider = services.BuildServiceProvider();

```