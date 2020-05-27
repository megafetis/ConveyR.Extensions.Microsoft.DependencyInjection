﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnitTest.Entities;
using СonveyoR;

namespace NUnitTest.Handlers
{
    [ProcessConfig(Group = "rollback")]
    class RollbackChangeHandler: AbstractProcessHandler<SimpleEntitiesStore, IHasFaledCount>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasFaledCount entity, CancellationToken cancellationToken = default)
        {
            entity.FailCount++;
            return Task.CompletedTask;
        }
    }
}
