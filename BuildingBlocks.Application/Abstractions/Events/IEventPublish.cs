using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Abstractions.Events
{
    public interface IEventPublish
    {
        Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken);
    }
}
