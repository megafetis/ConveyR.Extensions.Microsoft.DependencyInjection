using System;
using System.Threading;
using System.Threading.Tasks;
using NUnitTest.Entities;
using СonveyoR;

namespace NUnitTest.Handlers
{
    class GenerateIdHandler: AbstractProcessHandler<SimpleEntitiesStore, IEntity>
    {
        protected override Task Process(SimpleEntitiesStore context, IEntity entity,CancellationToken cancellationToken=default)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString("N");
            }
            return Task.CompletedTask;
        }
    }
}
