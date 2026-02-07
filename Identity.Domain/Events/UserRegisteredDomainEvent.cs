using BuildingBlocks.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Events
{
    public sealed class UserRegisteredDomainEvent : IDomainEvent
    {
        public Guid UserId { get; }
        public string Email { get; }
        public DateTime OccurredOn { get;}



       

        public UserRegisteredDomainEvent(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
