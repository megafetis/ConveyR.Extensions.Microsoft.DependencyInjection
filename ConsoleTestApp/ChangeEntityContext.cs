using System.Threading.Tasks;
using ConsoleTestApp.Entities;
using СonveyoR;

namespace ConsoleTestApp
{
    public class ChangeEntityContext
    {
        private readonly IConveyor _conveyor;

        public ChangeEntityContext(IConveyor conveyor)
        {
            _conveyor = conveyor;
        }
        public async Task ChangeEntity(IEntity entity, object payload)
        {
            await _conveyor.Process(this, ProcessCase.PreProcess, entity, payload);
        }

        public async Task AfterChangeEntity(IEntity entity, object payload = null)
        {
            await _conveyor.Process(this, ProcessCase.PostProcess, entity, payload);
        }

        public async Task RollbackChangeEntitiy(IEntity entity, object payload = null)
        {
            await _conveyor.Process(this, ProcessCase.RollbackProcess, entity, payload);
        }
    }
}
