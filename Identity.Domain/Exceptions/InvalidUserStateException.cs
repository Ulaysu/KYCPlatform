using BuildingBlocks.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Exceptions
{
    public sealed class InvalidUserStateException : DomainException
    {
            public InvalidUserStateException(string message) : base(message)
            {

            }
    }
}
