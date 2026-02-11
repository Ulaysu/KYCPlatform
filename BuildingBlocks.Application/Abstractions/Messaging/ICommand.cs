using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Abstractions.Messaging
{
    public interface ICommand<out TResult>
    {
    }
}
