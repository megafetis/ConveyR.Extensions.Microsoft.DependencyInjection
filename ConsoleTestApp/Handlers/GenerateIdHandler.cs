using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    class GenerateIdHandler: AbstractProcessHandler<SimpleEntitiesStore, IEntity>
    {
        protected override Task Process(SimpleEntitiesStore context, IEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString("N");
            }
            return Task.CompletedTask;
        }
    }
}
