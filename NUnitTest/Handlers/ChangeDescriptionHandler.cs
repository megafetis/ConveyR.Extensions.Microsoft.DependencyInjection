using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnitTest.Entities;
using NUnitTest.Payloads;
using СonveyoR;

namespace NUnitTest.Handlers
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
