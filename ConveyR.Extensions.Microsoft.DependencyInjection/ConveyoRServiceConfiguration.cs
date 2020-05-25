using Microsoft.Extensions.DependencyInjection;
using System;
using СonveyoR;

namespace ConveyoR
{
    public class ConveyoRServiceConfiguration
    {
        public Type ConveyorImplementationType { get; private set; }
        public ServiceLifetime Lifetime { get; private set; }

        public ConveyoRServiceConfiguration()
        {
            ConveyorImplementationType = typeof(Conveyor);
            Lifetime = ServiceLifetime.Transient;
        }

        public ConveyoRServiceConfiguration Using<TConveyor>() where TConveyor : IConveyor
        {
            ConveyorImplementationType = typeof(TConveyor);
            return this;
        }

        public ConveyoRServiceConfiguration AsSingleton()
        {
            Lifetime = ServiceLifetime.Singleton;
            return this;
        }

        public ConveyoRServiceConfiguration AsScoped()
        {
            Lifetime = ServiceLifetime.Scoped;
            return this;
        }

        public ConveyoRServiceConfiguration AsTransient()
        {
            Lifetime = ServiceLifetime.Transient;
            return this;
        }
    }
}
