using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    [ProcessConfig(Group = "after")]
    class TimestampEntityPostHandler: AbstractProcessHandler<SimpleEntitiesStore,ITimestampedEntity>
    {
        protected override Task Process(SimpleEntitiesStore context, ITimestampedEntity entity)
        {
            entity.Timestamp = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
