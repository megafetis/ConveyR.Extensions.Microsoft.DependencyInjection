using System;
using System.Threading.Tasks;
using NUnitTest.Entities;
using NUnitTest.Payloads;
using СonveyoR;

namespace NUnitTest.Handlers
{
    class ChangeDescriptionHandler:AbstractProcessHandler<SimpleEntitiesStore, IHasDescription,IHasDescriptionPayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasDescription entity, IHasDescriptionPayload payload)
        {
            entity.Description = payload.Description;
            return Task.CompletedTask;
        }
    }
}
