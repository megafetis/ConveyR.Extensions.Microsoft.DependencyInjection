using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnitTest.Entities;
using NUnitTest.Payloads;
using СonveyoR;

namespace NUnitTest.Handlers
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
