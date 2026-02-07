using BuildingBlocks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Events
{
    public sealed class UserRegistered : IDomainEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public DateTime OccuredOn { get;}

        public DateTime OccurredOn => throw new NotImplementedException();

        public UserRegistered(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
            OccuredOn = DateTime.UtcNow;
        }
    }
}
