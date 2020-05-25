using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnitTest.Entities;
using СonveyoR;

namespace NUnitTest
{
    public class SimpleEntitiesStore
    {
        private readonly IConveyor _conveyor;

        public SimpleEntitiesStore(IConveyor conveyor)
        {
            _conveyor = conveyor;
        }
        public async Task ChangeEntity(IEntity entity, object payload)
        {
            await _conveyor.Process(this, entity, payload);
        }

        public async Task AfterChangeEntity(IEntity entity, object payload = null)
        {
            await _conveyor.Process(this,  entity, payload,"after");
        }

        public async Task RollbackChangeEntitiy(IEntity entity, object payload = null)
        {
            await _conveyor.Process(this, entity, payload,"rollback");
        }
    }
}
