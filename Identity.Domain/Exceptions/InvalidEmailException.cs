using BuildingBlocks.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Exceptions
{
    public sealed class InvalidEmailException : DomainException
    {
        public InvalidEmailException(string message) : base(message)
        {
        }
    }
}
