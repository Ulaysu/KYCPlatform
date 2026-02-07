using BuildingBlocks.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Exceptions
{
    public sealed class InvalidUserRoleException : DomainException
    {
        public InvalidUserRoleException(string message) : base(message)
        {
            
        }
    }
}
