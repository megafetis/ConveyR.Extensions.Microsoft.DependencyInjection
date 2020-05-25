using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp.Handlers
{
    [ProcessConfig(Group = "rollback")]
    class RollbackChangeHandler: AbstractProcessHandler<SimpleEntitiesStore, IHasFaledCount>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasFaledCount entity)
        {
            entity.FailCount++;
            return Task.CompletedTask;
        }
    }
}
