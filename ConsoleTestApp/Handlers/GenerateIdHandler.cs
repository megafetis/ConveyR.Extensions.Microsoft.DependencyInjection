using System;
using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    class GenerateIdHandler:ProcessStepHandler<ChangeEntityContext, IEntity>
    {
        protected override Task Process(ChangeEntityContext context, IEntity entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString("N");
            }
            return Task.CompletedTask;
        }
    }
}
