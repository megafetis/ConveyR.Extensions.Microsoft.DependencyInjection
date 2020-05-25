using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    [ProcessOrder(ProcessCase.RollbackProcess)]
    class RollbackChangeHandler:ProcessStepHandler<SimpleEntitiesStore, IHasFaledCount>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasFaledCount entity)
        {
            entity.FailCount++;
            return Task.CompletedTask;
        }
    }
}
