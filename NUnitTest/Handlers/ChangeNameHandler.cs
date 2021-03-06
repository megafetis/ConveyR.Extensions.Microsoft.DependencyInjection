﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConveyR;
using NUnitTest.Entities;
using NUnitTest.Payloads;

namespace NUnitTest.Handlers
{
    public class ChangeNameHandler: AbstractProcessHandler<SimpleEntitiesStore, IHasName,IHasNamePayload>
    {
        protected override Task Process(SimpleEntitiesStore context, IHasName entity, IHasNamePayload payload, CancellationToken cancellationToken = default)
        {
            if(payload.Name==null)
                throw new ArgumentNullException("Name","Entity name must be named");
            entity.Name = payload.Name;
            return Task.CompletedTask;
        }
    }
}
