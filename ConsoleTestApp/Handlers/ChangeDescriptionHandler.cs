using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    class ChangeDescriptionHandler:ProcessStepHandler<ChangeEntityContext, IHasDescription,IHasDescriptionPayload>
    {
        protected override Task Process(ChangeEntityContext context, IHasDescription entity, IHasDescriptionPayload payload)
        {
            entity.Description = payload.Description;
            return Task.CompletedTask;
        }
    }
}
