using System;
using System.Threading;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using ConveyR;

namespace ConsoleTestApp.Handlers
{
    [ProcessConfig(Group = "after")]
    class TimestampEntityPostHandler: AbstractProcessHandler<SimpleEntitiesStore,ITimestampedEntity>
    {
        protected override Task Process(SimpleEntitiesStore context, ITimestampedEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Timestamp = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
