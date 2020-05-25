using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConsoleTestApp.Payloads;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    public class ChangeNameHandler:ProcessStepHandler<ChangeEntityContext, IHasName,IHasNamePayload>
    {
        protected override Task Process(ChangeEntityContext context, IHasName entity, IHasNamePayload payload)
        {
            if(payload.Name==null)
                throw new ArgumentNullException("Name","Entity name must be named");
            entity.Name = payload.Name;
            return Task.CompletedTask;
        }
    }
}
