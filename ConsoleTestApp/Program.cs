using System;
using ConsoleTestApp.Handlers;
using ConveyR;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = BuildServices();

            var conveyor = services.GetService<IConveyor>();


            var someHandler = services.GetService<ChangeNameHandler>();
        }

        private static ServiceProvider BuildServices()
        {
            var services = new ServiceCollection();
            services.AddConveyR();
            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
