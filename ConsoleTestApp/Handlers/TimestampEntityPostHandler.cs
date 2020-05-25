using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    [ProcessOrder(ProcessCase.PostProcess)]
    class TimestampEntityPostHandler:ProcessStepHandler<ChangeEntityContext,ITimestampedEntity>
    {
        protected override Task Process(ChangeEntityContext context, ITimestampedEntity entity)
        {
            entity.Timestamp = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
