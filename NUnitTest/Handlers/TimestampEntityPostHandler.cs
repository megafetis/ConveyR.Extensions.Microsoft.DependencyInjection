using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ConveyR;
using NUnitTest.Entities;


namespace NUnitTest.Handlers
{
    [ProcessConfig(Group = "after")]
    class TimestampEntityPostHandler:AbstractProcessHandler<SimpleEntitiesStore,ITimestampedEntity>
    {
        protected override Task Process(SimpleEntitiesStore context, ITimestampedEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Timestamp = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
