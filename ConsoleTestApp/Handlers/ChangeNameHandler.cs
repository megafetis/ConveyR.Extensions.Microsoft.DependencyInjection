using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using ConveyR;

namespace ConsoleTestApp.Handlers
{
    public class ChangeNameHandler: AbstractProcessHandler<SimpleEntitiesStore, IHasName,IHasNamePayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasName entity, IHasNamePayload payload, CancellationToken cancellationToken = default)
        {
            if(payload.Name==null)
                throw new ArgumentNullException("Name","Entity name must be named");
            entity.Name = payload.Name;
            return Task.CompletedTask;
        }
    }
}
