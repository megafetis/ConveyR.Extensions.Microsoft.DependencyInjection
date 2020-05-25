using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    public class ChangeNameHandler:ProcessStepHandler<SimpleEntitiesStore, IHasName,IHasNamePayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasName entity, IHasNamePayload payload)
        {
            if(payload.Name==null)
                throw new ArgumentNullException("Name","Entity name must be named");
            entity.Name = payload.Name;
            return Task.CompletedTask;
        }
    }
}
