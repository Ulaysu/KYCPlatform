using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Abstractions.Events
{
    public interface IIntegrationEvent
    {
        Guid EventId { get; }
        DateTimeOffset OccurredOn { get; }
    }
}
