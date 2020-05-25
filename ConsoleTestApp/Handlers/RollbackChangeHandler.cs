using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    [ProcessOrder(ProcessCase.RollbackProcess)]
    class RollbackChangeHandler:ProcessStepHandler<ChangeEntityContext, IHasFaledCount>
    {
        protected override Task Process(ChangeEntityContext context, IHasFaledCount entity)
        {
            entity.FailCount++;
            return Task.CompletedTask;
        }
    }
}
