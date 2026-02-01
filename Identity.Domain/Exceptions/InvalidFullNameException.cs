using BuildingBlocks.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Exceptions
{
    public sealed class InvalidFullNameException : DomainException
    {
        public InvalidFullNameException(string message) : base(message)
        {
        }
    }
}
