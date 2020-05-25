using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    class ChangeDescriptionHandler:ProcessStepHandler<SimpleEntitiesStore, IHasDescription,IHasDescriptionPayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasDescription entity, IHasDescriptionPayload payload)
        {
            entity.Description = payload.Description;
            return Task.CompletedTask;
        }
    }
}
