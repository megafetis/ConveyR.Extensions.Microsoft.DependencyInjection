using System;
using ConsoleTestApp.Handlers;
using Microsoft.Extensions.DependencyInjection;
using СonveyoR;

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
            services.AddConveyorR();
            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
