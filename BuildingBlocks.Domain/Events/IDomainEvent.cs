using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Domain.Events
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
