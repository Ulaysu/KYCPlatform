using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Abstractions.Messaging
{
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
