using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Abstractions.Persistence
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
