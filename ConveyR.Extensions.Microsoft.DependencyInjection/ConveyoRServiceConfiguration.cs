using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConveyR
{
    /// <summary>
    /// Customization of registration ConveyR services
    /// </summary>
    public class ConveyRServiceConfiguration
    {
        public Type ConveyorImplementationType { get; private set; }
        public ServiceLifetime Lifetime { get; private set; }

        public ConveyRServiceConfiguration()
        {
            ConveyorImplementationType = typeof(Conveyor);
            Lifetime = ServiceLifetime.Transient;
        }

        public ConveyRServiceConfiguration Using<TConveyor>() where TConveyor : IConveyor
        {
            ConveyorImplementationType = typeof(TConveyor);
            return this;
        }

        public ConveyRServiceConfiguration AsSingleton()
        {
            Lifetime = ServiceLifetime.Singleton;
            return this;
        }

        public ConveyRServiceConfiguration AsScoped()
        {
            Lifetime = ServiceLifetime.Scoped;
            return this;
        }

        public ConveyRServiceConfiguration AsTransient()
        {
            Lifetime = ServiceLifetime.Transient;
            return this;
        }
    }
}
