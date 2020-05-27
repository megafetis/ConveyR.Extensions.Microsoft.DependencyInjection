using System.Threading;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using ConveyR;

namespace ConsoleTestApp.Handlers
{
    class ChangeDescriptionHandler:AbstractProcessHandler<SimpleEntitiesStore, IHasDescription,IHasDescriptionPayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasDescription entity, IHasDescriptionPayload payload,CancellationToken cancellationToken=default)
        {
            entity.Description = payload.Description;
            return Task.CompletedTask;
        }
    }
}
